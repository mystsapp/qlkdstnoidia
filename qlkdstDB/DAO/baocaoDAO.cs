using PagedList;
using qlkdstDB.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace qlkdstDB.DAO
{
    public class baocaoDAO
    {
        qlkdtrEntities db = null;
        public baocaoDAO()
        {
            db = new qlkdtrEntities();
        }

        public string GetSoHopDong(string sgtcode)
        {
            var soHopDong = db.tour.Where(x => x.sgtcode == sgtcode);
            return soHopDong.FirstOrDefault().sohopdong;
        }

        public DataSet BCDoanhThuTheoTuyen2Nam(DateTime bdate, DateTime edate, DateTime bdate1, DateTime edate1, string nguoitao, string roles, string chinhanh, string sCongTyPre)
        {
            DataSet ds = new DataSet();
            string constr = ConfigurationManager.ConnectionStrings["strkhi_goiprocedure"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(constr))
            {
                SqlCommand cmdReport = sqlConn.CreateCommand();
                cmdReport.CommandType = CommandType.StoredProcedure;
                cmdReport.CommandText = "pro_BCDoanhThuTheoTuyen2Nam";
                cmdReport.Parameters.Add(new SqlParameter("bdate", bdate));
                cmdReport.Parameters.Add(new SqlParameter("edate", edate));
                cmdReport.Parameters.Add(new SqlParameter("bdate1", bdate1));
                cmdReport.Parameters.Add(new SqlParameter("edate1", edate1));
                cmdReport.Parameters.Add(new SqlParameter("nguoitao", nguoitao));
                cmdReport.Parameters.Add(new SqlParameter("role", roles));
                cmdReport.Parameters.Add(new SqlParameter("chinhanh", chinhanh));
                cmdReport.Parameters.Add(new SqlParameter("mactpre", sCongTyPre));

                SqlDataAdapter daReport = new SqlDataAdapter(cmdReport);
                using (cmdReport)
                {
                    daReport.Fill(ds);
                }
            }


            return ds;
        }

        public DataSet BCSKTheoTuyen2Nam(DateTime bdate, DateTime edate, DateTime bdate1, DateTime edate1, string nguoitao, string roles, string chinhanh, string sCongTyPre)
        {
            DataSet ds = new DataSet();
            string constr = ConfigurationManager.ConnectionStrings["strkhi_goiprocedure"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(constr))
            {
                SqlCommand cmdReport = sqlConn.CreateCommand();
                cmdReport.CommandType = CommandType.StoredProcedure;
                cmdReport.CommandText = "pro_BCSKTheoTuyen2Nam";
                cmdReport.Parameters.Add(new SqlParameter("bdate", bdate));
                cmdReport.Parameters.Add(new SqlParameter("edate", edate));
                cmdReport.Parameters.Add(new SqlParameter("bdate1", bdate1));
                cmdReport.Parameters.Add(new SqlParameter("edate1", edate1));
                cmdReport.Parameters.Add(new SqlParameter("nguoitao", nguoitao));
                cmdReport.Parameters.Add(new SqlParameter("role", roles));
                cmdReport.Parameters.Add(new SqlParameter("chinhanh", chinhanh));
                cmdReport.Parameters.Add(new SqlParameter("mactpre", sCongTyPre));

                SqlDataAdapter daReport = new SqlDataAdapter(cmdReport);
                using (cmdReport)
                {
                    daReport.Fill(ds);
                }
            }


            return ds;
        }

        public DataSet BCDoanhThuTheoPhongKDKD(DateTime bdate, DateTime edate, DateTime bdate1, DateTime edate1, string nguoitao, string roles, string chinhanh, string sCongTyPre)
        {
            DataSet ds = new DataSet();
            string constr = ConfigurationManager.ConnectionStrings["strkhi_goiprocedure"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(constr))
            {
                SqlCommand cmdReport = sqlConn.CreateCommand();
                cmdReport.CommandType = CommandType.StoredProcedure;
                cmdReport.CommandText = "pro_BCDoanhThuPhongKDKD";
                cmdReport.Parameters.Add(new SqlParameter("bdate", bdate));
                cmdReport.Parameters.Add(new SqlParameter("edate", edate));
                cmdReport.Parameters.Add(new SqlParameter("bdate1", bdate1));
                cmdReport.Parameters.Add(new SqlParameter("edate1", edate1));
                cmdReport.Parameters.Add(new SqlParameter("nguoitao", nguoitao));
                cmdReport.Parameters.Add(new SqlParameter("role", roles));
                cmdReport.Parameters.Add(new SqlParameter("chinhanh", chinhanh));
                cmdReport.Parameters.Add(new SqlParameter("mactpre", sCongTyPre));

                SqlDataAdapter daReport = new SqlDataAdapter(cmdReport);
                using (cmdReport)
                {
                    daReport.Fill(ds);
                }
            }


            return ds;
        }

        public DataSet BCTheoNhomTT(DateTime bdate, DateTime edate, string nguoitao, string roles, string sChinhanh, string sCongTyPre)
        {
            DataSet ds = new DataSet();
            string constr = ConfigurationManager.ConnectionStrings["strkhi_goiprocedure"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(constr))
            {
                SqlCommand cmdReport = sqlConn.CreateCommand();
                cmdReport.CommandType = CommandType.StoredProcedure;
                cmdReport.CommandText = "pro_BCDoanhThuTheoNhomThiTruong";
                cmdReport.Parameters.Add(new SqlParameter("bdate", bdate));
                cmdReport.Parameters.Add(new SqlParameter("edate", edate));
                cmdReport.Parameters.Add(new SqlParameter("nguoitao", nguoitao));
                cmdReport.Parameters.Add(new SqlParameter("role", roles));
                cmdReport.Parameters.Add(new SqlParameter("chinhanh", sChinhanh));
                cmdReport.Parameters.Add(new SqlParameter("mactpre", sCongTyPre));
                SqlDataAdapter daReport = new SqlDataAdapter(cmdReport);
                using (cmdReport)
                {
                    daReport.Fill(ds);
                }
            }


            return ds;
        }
        
        public DataSet BCDTTheoNganhNghe(DateTime bdate, DateTime edate, string nguoitao, string roles, string chinhanh, string sCongTyPre, int nganhNgheId, string nguontour)
        {
            DataSet ds = new DataSet();
            string constr = ConfigurationManager.ConnectionStrings["strkhi_goiprocedure"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(constr))
            {
                SqlCommand cmdReport = sqlConn.CreateCommand();
                cmdReport.CommandType = CommandType.StoredProcedure;
                cmdReport.CommandText = "pro_BCDTTheoTuyenND"; // BCDoanhSoTheoTuyenND --> co nghanhnghe
                cmdReport.Parameters.Add(new SqlParameter("bdate", bdate));
                cmdReport.Parameters.Add(new SqlParameter("edate", edate));
                //cmdReport.Parameters.Add(new SqlParameter("bdate1", bdate1));
                //cmdReport.Parameters.Add(new SqlParameter("edate1", edate1));
                cmdReport.Parameters.Add(new SqlParameter("nguoitao", nguoitao));
                cmdReport.Parameters.Add(new SqlParameter("role", roles));
                cmdReport.Parameters.Add(new SqlParameter("chinhanh", chinhanh));
                cmdReport.Parameters.Add(new SqlParameter("mactpre", sCongTyPre));
                cmdReport.Parameters.Add(new SqlParameter("nganhNgheId", nganhNgheId));
                cmdReport.Parameters.Add(new SqlParameter("nguontour", nguontour));

                SqlDataAdapter daReport = new SqlDataAdapter(cmdReport);
                using (cmdReport)
                {
                    daReport.Fill(ds);
                }
            }


            return ds;
        }

        public DataSet BCDoanhThuTheoSales(DateTime bdate, DateTime edate, string nguoitao, string roles, string sChinhanh, string sCongTyPre,string sHoTen)
        {
            DataSet ds = new DataSet();
            string constr = ConfigurationManager.ConnectionStrings["strkhi_goiprocedure"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(constr))
            {
                SqlCommand cmdReport = sqlConn.CreateCommand();
                cmdReport.CommandType = CommandType.StoredProcedure;
                cmdReport.CommandText = "pro_BCDoanhThuTheoSales";
                cmdReport.Parameters.Add(new SqlParameter("bdate", bdate));
                cmdReport.Parameters.Add(new SqlParameter("edate", edate));
                cmdReport.Parameters.Add(new SqlParameter("nguoitao", nguoitao));
                cmdReport.Parameters.Add(new SqlParameter("role", roles));
                cmdReport.Parameters.Add(new SqlParameter("chinhanh", sChinhanh));
                cmdReport.Parameters.Add(new SqlParameter("mactpre", sCongTyPre));
                cmdReport.Parameters.Add(new SqlParameter("hoten", sHoTen));
                SqlDataAdapter daReport = new SqlDataAdapter(cmdReport);
                using (cmdReport)
                {
                    daReport.Fill(ds);
                }
            }


            return ds;
        }

        public DataSet BCDTSKGiaTourBQ(DateTime bdate, DateTime edate, DateTime bdate1, DateTime edate1, string nguoitao, string roles, string sChinhanh, string sCongTyPre)
        {
            DataSet ds = new DataSet();
            string constr = ConfigurationManager.ConnectionStrings["strkhi_goiprocedure"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(constr))
            {
                SqlCommand cmdReport = sqlConn.CreateCommand();
                cmdReport.CommandType = CommandType.StoredProcedure;
                cmdReport.CommandText = "pro_BCDTSKGiaTourBQ";
                cmdReport.Parameters.Add(new SqlParameter("bdate", bdate));
                cmdReport.Parameters.Add(new SqlParameter("edate", edate));
                cmdReport.Parameters.Add(new SqlParameter("bdate1", bdate1));
                cmdReport.Parameters.Add(new SqlParameter("edate1", edate1));
                cmdReport.Parameters.Add(new SqlParameter("nguoitao", nguoitao));
                cmdReport.Parameters.Add(new SqlParameter("role", roles));
                cmdReport.Parameters.Add(new SqlParameter("chinhanh", sChinhanh));
                cmdReport.Parameters.Add(new SqlParameter("mactpre", sCongTyPre));

                SqlDataAdapter daReport = new SqlDataAdapter(cmdReport);
                using (cmdReport)
                {
                    daReport.Fill(ds);
                }
            }

            return ds;
        }


        public DataSet BCDTSKTheoTuyen(DateTime bdate, DateTime edate, DateTime bdate1, DateTime edate1, string nguoitao, string roles, string sChinhanh, string sCongTyPre)
        {
            DataSet ds = new DataSet();
            string constr = ConfigurationManager.ConnectionStrings["strkhi_goiprocedure"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(constr))
            {
                SqlCommand cmdReport = sqlConn.CreateCommand();
                cmdReport.CommandType = CommandType.StoredProcedure;
                cmdReport.CommandText = "pro_BCDTSKTheoTuyen";
                cmdReport.Parameters.Add(new SqlParameter("bdate", bdate));
                cmdReport.Parameters.Add(new SqlParameter("edate", edate));
                cmdReport.Parameters.Add(new SqlParameter("bdate1", bdate1));
                cmdReport.Parameters.Add(new SqlParameter("edate1", edate1));
                cmdReport.Parameters.Add(new SqlParameter("nguoitao", nguoitao));
                cmdReport.Parameters.Add(new SqlParameter("role", roles));
                cmdReport.Parameters.Add(new SqlParameter("chinhanh", sChinhanh));
                cmdReport.Parameters.Add(new SqlParameter("mactpre", sCongTyPre));

                SqlDataAdapter daReport = new SqlDataAdapter(cmdReport);
                using (cmdReport)
                {
                    daReport.Fill(ds);
                }
            }


            return ds;
        }


        public DataSet BCDoanhThuTheoTuyen(DateTime bdate, DateTime edate, string nguoitao, string roles, string sChinhanh, string sCongTyPre)
        {
            DataSet ds = new DataSet();
            string constr = ConfigurationManager.ConnectionStrings["strkhi_goiprocedure"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(constr))
            {
                SqlCommand cmdReport = sqlConn.CreateCommand();
                cmdReport.CommandType = CommandType.StoredProcedure;
                cmdReport.CommandText = "pro_BCDoanhThuTheoTuyen";
                cmdReport.Parameters.Add(new SqlParameter("bdate", bdate));
                cmdReport.Parameters.Add(new SqlParameter("edate", edate));
                cmdReport.Parameters.Add(new SqlParameter("nguoitao", nguoitao));
                cmdReport.Parameters.Add(new SqlParameter("role", roles));
                cmdReport.Parameters.Add(new SqlParameter("chinhanh", sChinhanh));
                cmdReport.Parameters.Add(new SqlParameter("mactpre", sCongTyPre));

                SqlDataAdapter daReport = new SqlDataAdapter(cmdReport);
                using (cmdReport)
                {
                    daReport.Fill(ds);
                }
            }


            return ds;
        }

        public DataSet BCTOUR(DateTime bdate, DateTime edate, string nguoitao, string roles, string sChinhanh, string trangthai, string sCongTyPre)
        {
            DataSet ds = new DataSet();
            string constr = ConfigurationManager.ConnectionStrings["strkhi_goiprocedure"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(constr))
            {
                SqlCommand cmdReport = sqlConn.CreateCommand();
                cmdReport.CommandType = CommandType.StoredProcedure;
                cmdReport.CommandText = "pro_BCTOUR";
                cmdReport.Parameters.Add(new SqlParameter("bdate", bdate));
                cmdReport.Parameters.Add(new SqlParameter("edate", edate));
                cmdReport.Parameters.Add(new SqlParameter("nguoitao", nguoitao));
                cmdReport.Parameters.Add(new SqlParameter("role", roles));
                cmdReport.Parameters.Add(new SqlParameter("chinhanh", sChinhanh));
                cmdReport.Parameters.Add(new SqlParameter("trangthai", trangthai));
                cmdReport.Parameters.Add(new SqlParameter("mactpre", sCongTyPre));

                SqlDataAdapter daReport = new SqlDataAdapter(cmdReport);
                using (cmdReport)
                {
                    daReport.Fill(ds);
                }
            }


            return ds;
        }

        public DataSet BCCPHH(DateTime bdate, DateTime edate, string nguoitao, string roles, string sChinhanh, string sCongTyPre)
        {
            DataSet ds = new DataSet();
            string constr = ConfigurationManager.ConnectionStrings["strkhi_goiprocedure"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(constr))
            {
                SqlCommand cmdReport = sqlConn.CreateCommand();
                cmdReport.CommandType = CommandType.StoredProcedure;
                cmdReport.CommandText = "pro_BCCPHH";
                cmdReport.Parameters.Add(new SqlParameter("bdate", bdate));
                cmdReport.Parameters.Add(new SqlParameter("edate", edate));
                cmdReport.Parameters.Add(new SqlParameter("nguoitao", nguoitao));
                cmdReport.Parameters.Add(new SqlParameter("role", roles));
                cmdReport.Parameters.Add(new SqlParameter("chinhanh", sChinhanh));
                cmdReport.Parameters.Add(new SqlParameter("mactpre", sCongTyPre));

                SqlDataAdapter daReport = new SqlDataAdapter(cmdReport);
                using (cmdReport)
                {
                    daReport.Fill(ds);
                }
            }


            return ds;
        }
        public IEnumerable<DSTheoNgayDiTourModel> getdsDoanOBHD_1(DateTime bdate, DateTime edate, string nguoitao, string roles, string chinhanh, string sCongTyPre, string loaitour, string nguontour)
        {
            var parameter = new SqlParameter[]
               {
                    new SqlParameter("bdate", bdate),
                    new SqlParameter("edate", edate),
                    new SqlParameter("nguoitao", nguoitao),
                    new SqlParameter("role", roles),
                    new SqlParameter("chinhanh", chinhanh),
                    new SqlParameter("mactpre", sCongTyPre),
                    new SqlParameter("loaitourid", loaitour),
                    new SqlParameter("nguontour", nguontour)

               };
            var obj = db.Database.SqlQuery<DSTheoNgayDiTourModel>("pro_BCDTTheoTuyenND @bdate, @edate, @nguoitao, @role, @chinhanh, @mactpre, @loaitourid, @nguontour", parameter);
            var abc = obj.ToList();
            ////string cn = Session["chinhanh"].ToString();
            //var obj = db.Database.SqlQuery<DSTheoNgayDiTourModel>("exec dbo.pro_BCDTTheoTuyenND @bdate, @edate, @nguoitao, @role, @chinhanh, @mactpre, @loaitourid, @nguontour",
            //                                                   new SqlParameter[]
            //                                                           {
            //                                                                    new SqlParameter("@bdate", (object)bdate ?? DBNull.Value),
            //                                                                    new SqlParameter("@edate", (object)edate ?? DBNull.Value),
            //                                                                    new SqlParameter("@nguoitao", (object)nguoitao ?? DBNull.Value),
            //                                                                    new SqlParameter("@role", (object)roles ?? DBNull.Value),
            //                                                                    new SqlParameter("@chinhanh", chinhanh),
            //                                                                    new SqlParameter("@mactpre", sCongTyPre),
            //                                                                    new SqlParameter("@loaitourid", loaitour),
            //                                                                    new SqlParameter("@nguontour", nguontour)
            //                                                           }
            //                                                   ).ToList();
            return obj;
        }

        public DataSet BCDTTheoTuyenND(DateTime bdate, DateTime edate, string nguoitao, string roles, string chinhanh, string sCongTyPre,string loaitour,string nguontour)
        {
            DataSet ds = new DataSet();
            string constr = ConfigurationManager.ConnectionStrings["strkhi_goiprocedure"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(constr))
            {
                SqlCommand cmdReport = sqlConn.CreateCommand();
                cmdReport.CommandType = CommandType.StoredProcedure;
                cmdReport.CommandText = "pro_BCDTTheoTuyenND";
                cmdReport.Parameters.Add(new SqlParameter("bdate", bdate));
                cmdReport.Parameters.Add(new SqlParameter("edate", edate));
                //cmdReport.Parameters.Add(new SqlParameter("bdate1", bdate1));
                //cmdReport.Parameters.Add(new SqlParameter("edate1", edate1));
                cmdReport.Parameters.Add(new SqlParameter("nguoitao", nguoitao));
                cmdReport.Parameters.Add(new SqlParameter("role", roles));
                cmdReport.Parameters.Add(new SqlParameter("chinhanh", chinhanh));
                cmdReport.Parameters.Add(new SqlParameter("mactpre", sCongTyPre));
                cmdReport.Parameters.Add(new SqlParameter("loaitourid", loaitour));
                cmdReport.Parameters.Add(new SqlParameter("nguontour", nguontour));

                SqlDataAdapter daReport = new SqlDataAdapter(cmdReport);
                using (cmdReport)
                {
                    daReport.Fill(ds);
                }
            }

            //var abc = ds.Tables[0].AsEnumerable();

            //List<DSTheoNgayDiTourModel> dsTheoNgayDis = new List<DSTheoNgayDiTourModel>();
            //foreach(var item in abc)
            //{
            //    DSTheoNgayDiTourModel dsTheoNgayDi = new DSTheoNgayDiTourModel();
            //    dsTheoNgayDi.Sgtcode = item.Field<string>("Sgtcode");
            //    dsTheoNgayDi.SoHopDong = item.Field<string>("SoHopDong");// string.IsNullOrEmpty(item.Field<string>("SoHopDong")) ? "" : item.Field<string>("SoHopDong");
            //    dsTheoNgayDi.BatDau = item.Field<DateTime>("BatDau");
            //    dsTheoNgayDi.KetThuc = item.Field<DateTime>("KetThuc");
            //    dsTheoNgayDi.TuyenTQ = item.Field<string>("TuyenTQ");
            //    dsTheoNgayDi.SoKhachTT = item.Field<int>("SoKhachTT");
            //    dsTheoNgayDi.TrangThai = item.Field<string>("TrangThai");
            //    dsTheoNgayDi.NguoiTao = item.Field<string>("NguoiTao");
            //    dsTheoNgayDi.TenKH = item.Field<string>("TenKH");
            //    dsTheoNgayDi.LoaiTourId = item.Field<string>("LoaiTourId");
            //    dsTheoNgayDi.NguonTour = item.Field<string>("NguonTour");
            //    dsTheoNgayDi.NganhNghe = item.Field<string>("NganhNghe");

            //    dsTheoNgayDis.Add(dsTheoNgayDi);
            //}


            List < DSTheoNgayDiTourModel > list = ds.Tables[0].AsEnumerable().Select(m => new DSTheoNgayDiTourModel()
            {
                Sgtcode = m.Field<string>("Sgtcode"),
                SoHopDong = m.Field<string>("SoHopDong") == null ? "": m.Field<string>("SoHopDong"),
                BatDau = m.Field<DateTime>("BatDau"),

                KetThuc = m.Field<DateTime>("KetThuc"),
                TuyenTQ = m.Field<string>("TuyenTQ"),
                SoKhachTT = m.Field<int>("SoKhachTT"),

                DoanhThuTT = Convert.ToDecimal(m.Field<decimal>("DoanhThuTT")),
                TrangThai = m.Field<string>("TrangThai"),
                NguoiTao = m.Field<string>("NguoiTao"),

                TenKH = m.Field<string>("TenKH"),
                LoaiTourId = m.Field<string>("LoaiTourId"),
                NguonTour = m.Field<string>("NguonTour"),
                NganhNghe = m.Field<string>("NganhNghe"),
            }).ToList();

            foreach (var item in list)
            {
                var tour = db.tour.Where(x => x.sgtcode == item.Sgtcode).FirstOrDefault();
                if (tour != null && !string.IsNullOrEmpty(tour.sohopdong))
                {
                    item.SoHopDong = tour.sohopdong;
                }
            }

            var tbl = EntityToTable.ToDataTable(list);
            ds.Tables.Add(tbl);
            //DataTable tbl1 = new DataTable();
            //tbl1 = ds.Tables[1];
            //DataTable tbl2 = new DataTable();
            //tbl2 = ds.Tables[2];
            //DataTable tbl3 = new DataTable();
            //tbl3 = ds.Tables[3];

            //DataSet set = new DataSet();
            //set.Tables.Add(tbl);
            //set.Tables.Add(tbl1);
            //set.Tables.Add(tbl2);
            //set.Tables.Add(tbl3);

            return ds;
            
        }
        
        //public List<tour> BCDTTheoTuyenND_List(DateTime bdate, DateTime edate, string nguoitao, string roles, string chinhanh, string sCongTyPre, string loaitour, string nguontour)
        //{

        //    IQueryable<tour> model = db.tour;

        //    //if (!String.IsNullOrEmpty(searchString))
        //    //{
        //    //    model = model.Where(x => x.sgtcode.Contains(searchString));
        //    //}

        //    DateTime d1 = bdate, d2 = edate;
        //    if (d1 != null && d2 != null)
        //    {
        //        model = model.Where(x => x.batdau != null && DbFunctions.TruncateTime(x.batdau.Value) >= DbFunctions.TruncateTime(d1) && DbFunctions.TruncateTime(x.batdau.Value) <= DbFunctions.TruncateTime(d2));
        //    }

        //    if (!String.IsNullOrEmpty(nguoitao))
        //    {
        //        model = model.Where(x => x.nguoitao == nguoitao);//.tenkh.Contains(tencongty));
        //    }

        //    //if (!String.IsNullOrEmpty(sohopdong))
        //    //{
        //    //    model = model.Where(x => x.sohopdong.Contains(sohopdong));
        //    //}

        //    //if (!String.IsNullOrEmpty(tuyentq))
        //    //{
        //    //    model = model.Where(x => x.tuyentq.Contains(tuyentq));
        //    //}

        //    //if (!String.IsNullOrEmpty(salenm))
        //    //{
        //    //    model = model.Where(x => x.nguoitao.Contains(salenm));
        //    //}


        //    if (sCongTyPre.Length > 0 && usr.role != "admin" && usr.role != "superadmin") //user co quyen theo vung mien
        //    {
        //        model = model.Where(x => sCongTyPre.Contains(x.chinhanh) || x.chinhanh == usr.chinhanh);
        //        //model = model.Where(x => new[] { "STA","STT","STC" }.Contains(x.chinhanh));
        //    }
        //    else
        //    {
        //        if (!String.IsNullOrEmpty(sChiNhanh) && usr.role != "admin" && usr.role != "superadmin")
        //        {
        //            model = model.Where(x => x.chinhanh == sChiNhanh);
        //        }
        //        //15/05: tam cho phep sales thay toan bo code cua chi nhanh
        //        if (usr.role == "salemanager") //chi thay code cua chi nhanh minh
        //        {
        //            model = model.Where(x => x.chinhanh == usr.chinhanh);

        //        }
        //        //15/05 tam thoi bo dieu kien nay
        //        //19/5 mo lai, sale chi thay doan cua minh
        //        if (usr != null && usr.role != "admin" && usr.role != "superadmin" && usr.role != "salemanager") //user chi thay du lieu do minh tao tru user admin hay superadmin
        //        {
        //            model = model.Where(x => x.nguoitao == usr.username || x.nguoitao.Contains(usr.fullName) || x.nguoisua == usr.username || x.nguoisua.Contains(usr.fullName));
        //        }
        //    }




        //    return model.OrderBy(x => x.batdau).ThenBy(x => x.ngaytao).ToList();//.ToPagedList(page, pagesize);
        //}

    }

    public static class EntityToTable
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> entityList) where T : class
        {
            try
            {
                var properties = typeof(T).GetProperties();
                var table = new DataTable();

                foreach (var property in properties)
                {
                    var type = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                    table.Columns.Add(property.Name, type);
                }
                foreach (var entity in entityList)
                {
                    table.Rows.Add(properties.Select(p => p.GetValue(entity, null)).ToArray());
                }
                return table;
            }
            catch
            {
                return null;
            }
        }



        //internal static DataTable ToDataTable(int result)
        //{
        //    throw new NotImplementedException();
        //}
    }

}
