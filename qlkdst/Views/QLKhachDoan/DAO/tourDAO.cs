using PagedList;
using qlkdstDB.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace qlkdstDB.DAO
{
    public class tourDAO
    {
        qlkdtrEntities db = null;
        public tourDAO()
        {
            db = new qlkdtrEntities();
        }

        public string TaoCodeDoan(string chinhanh, DateTime batdau, DateTime ketthuc, int sokhach, string tuyentq, string chudetour, string makh, string nguoitaotour)
        {
            string sOutputSgtCode = "";

            //doi voi noidia
            if (chinhanh == "STS") chinhanh = "STN";

            string constr = ConfigurationManager.ConnectionStrings["strkhi_goiprocedure"].ConnectionString;

            try
            {
                SqlConnection sqlConn = new SqlConnection(constr);
                sqlConn.Open();

                SqlCommand cmdReport = sqlConn.CreateCommand();
                cmdReport.CommandType = CommandType.StoredProcedure;
                cmdReport.CommandText = "spTaoCodeDoan";
                cmdReport.Parameters.Add(new SqlParameter("chinhanh", chinhanh));
                cmdReport.Parameters.Add(new SqlParameter("batdau", batdau));
                cmdReport.Parameters.Add(new SqlParameter("ketthuc", ketthuc));
                cmdReport.Parameters.Add(new SqlParameter("sokhach", sokhach));
                cmdReport.Parameters.Add(new SqlParameter("tuyentq", tuyentq));
                cmdReport.Parameters.Add(new SqlParameter("chudetour", chudetour));
                cmdReport.Parameters.Add(new SqlParameter("makh", makh));
                cmdReport.Parameters.Add(new SqlParameter("nguoitaotour", nguoitaotour));

                SqlParameter sgtcodeP = new SqlParameter();
                sgtcodeP.ParameterName = "sgtcode";
                sgtcodeP.Direction = ParameterDirection.Output;
                sgtcodeP.DbType = DbType.String;
                sgtcodeP.Size = 17;
                cmdReport.Parameters.Add(sgtcodeP);

                try
                {
                    int sqlRows = cmdReport.ExecuteNonQuery();
                    sOutputSgtCode = sgtcodeP.Value.ToString();

                    if (sqlRows > 0)
                        sOutputSgtCode = cmdReport.Parameters["sgtcode"].Value.ToString();
                }
                catch (Exception e)
                {

                }

            }
            catch (Exception e)
            {

            }

            //using (SqlConnection sqlConn = new SqlConnection(constr))
            //{

            //}           



            return sOutputSgtCode;
        }
        public List<quan> GetQuan(decimal[] maquocgia)
        {
            List<quan> lst = new List<quan>();                   

            var model =from s in db.quan select s;
            if (maquocgia != null)
            {
                model = from m in model where maquocgia.Contains(m.maquocgia) select m;
            }

            lst = model.ToList();
            return lst;
        }

        public object ListAllPageList(string searchString,DateTime d1,DateTime d2,string tencongty,string sohopdong,string sChiNhanh,string sDaily,users usr, int page, int pagesize)
        {
            IQueryable<tour> model = db.tour;            

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.sgtcode.Contains(searchString));
            }

            if (d1 != null && d2 != null)
            {
                model = model.Where(x => x.batdau != null && DbFunctions.TruncateTime(x.batdau.Value) >= DbFunctions.TruncateTime(d1) && DbFunctions.TruncateTime(x.batdau.Value) <= DbFunctions.TruncateTime(d2));
            }

            if (!String.IsNullOrEmpty(tencongty))
            {
                model = model.Where(x => x.tenkh.Contains(tencongty));
            }

            if (!String.IsNullOrEmpty(sohopdong))
            {
                model = model.Where(x => x.sohopdong.Contains(sohopdong));
            }

            if (!String.IsNullOrEmpty(sChiNhanh) && usr.role != "admin" && usr.role != "superadmin")
            {
                model = model.Where(x => x.chinhanh == sChiNhanh);
            }

            //if (!String.IsNullOrEmpty(sDaily))
            //{
            //    model = model.Where(x => x.daily == sDaily);
            //}

            if (usr.role == "salemanager") //chi thay code cua chi nhanh minh
            {
                model = model.Where(x => x.chinhanh == usr.chinhanh);

            }
            else if (usr != null && usr.role != "admin" && usr.role != "superadmin" && usr.role != "salemanager") //user chi thay du lieu do minh tao tru user admin hay superadmin
            {
                //model = model.Where(x => x.nguoitao == usr.userId || x.nguoisua == usr.userId);
                model = model.Where(x => x.nguoitao == usr.username || x.nguoisua == usr.username);
            }

            return model.OrderByDescending(x => x.batdau).ThenBy(x => x.ngaytao).ToPagedList(page, pagesize);
        }

        public List<tour> GetDsTour(string searchString, string tencongty, string sohopdong, string sChiNhanh, string sDaily, users usr)
        {
            IQueryable<tour> model = db.tour;

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.sgtcode.Contains(searchString));
            }            

            if (!String.IsNullOrEmpty(tencongty))
            {
                model = model.Where(x => x.tenkh.Contains(tencongty));
            }

            if (!String.IsNullOrEmpty(sohopdong))
            {
                model = model.Where(x => x.sohopdong.Contains(sohopdong));
            }

            if (!String.IsNullOrEmpty(sChiNhanh))
            {
                model = model.Where(x => x.chinhanh == sChiNhanh);
            }            

            if (usr != null && usr.role != "admin" && usr.role != "superadmin" && usr.role != "salemanager") //user chi thay du lieu do minh tao tru user admin hay superadmin
            {
                model = model.Where(x => x.nguoitao == usr.userId || x.nguoisua == usr.userId);
            }

            return model.OrderByDescending(x => x.ngaytao).ToList();
        }

        public List<dmkhachhang> GetDmKhachHang(string tengiaodich)
        {
            List<dmkhachhang> lst = db.dmkhachhang.Where(x => x.tengiaodich.Contains(tengiaodich)).OrderBy(x=>x.tengiaodich).ToList();
            return lst;
        }

        public object GetDmKh(string[] id)
        {
            IQueryable<dmkhachhang> lst = db.dmkhachhang;
                       
            if (id != null)
            {
                lst = from m in lst where id.Contains(m.makh) select m;
            }

            lst = lst.OrderBy(x => x.tengiaodich);             
            return lst;
        }

     

        public List<quan> GetQuanByLstId(decimal[] id)
        {
            List<quan> lst = new List<quan>();

            var model = from s in db.quan select s;
            if (id != null)
            {
                model = from m in model where id.Contains(m.maquan) select m;
            }

            model = model.OrderBy(x => x.tenquan);

            lst = model.ToList();
            return lst;
        }

      

        public tour Details(decimal id)
        {
            tour model = db.tour.Find(id);
            return model;
        }

      

        public string Update(tour model)
        {
            try
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return model.sgtcode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert(tour model)
        {
            try
            {
                db.tour.Add(model);
                db.SaveChanges();
                return model.sgtcode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      

        public string Delete(decimal id)
        {
            tour co = db.tour.Find(id);
            db.tour.Remove(co);
            db.SaveChanges();
            return id.ToString();
        }

        public string GetStrSTTCuaSoHopDong(int nam, int thang)
        {
            DataSet ds = GetSoHopDong(nam,thang);
            DataTable dt = ds.Tables[0];

            string sRes = "";
            if (dt.Rows.Count > 0)
            {
                sRes = dt.Rows[0]["stt"].ToString();
            }

            return sRes;
        }

        public DataSet GetSoHopDong(int nam,int thang)
        {
            DataSet ds = new DataSet();
            string constr = ConfigurationManager.ConnectionStrings["strkhi_goiprocedure"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(constr))
            {
                SqlCommand cmdReport = sqlConn.CreateCommand();
                cmdReport.CommandType = CommandType.StoredProcedure;
                cmdReport.CommandText = "spGetSoHopDong";
                cmdReport.Parameters.Add(new SqlParameter("nam", nam));
                cmdReport.Parameters.Add(new SqlParameter("thang", thang));                

                SqlDataAdapter daReport = new SqlDataAdapter(cmdReport);
                using (cmdReport)
                {
                    daReport.Fill(ds);
                }
            }


            return ds;
        }

    }
}
