using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImagesWebAPI.Controllers
{
    public class HomeController : Controller
    {

        public bool Infile(HttpPostedFileBase imgfile)
        {

            return (imgfile != null && imgfile.ContentLength > 0) ? true : false;

        }

        public ActionResult Index()
        {

            foreach (string Save in Request.Files)

            {

                if (!Infile(Request.Files[Save])) continue;

                string fileType = Request.Files[Save].ContentType;

                Stream file_Strm = Request.Files[Save].InputStream;

                string file_Name = Path.GetFileName(Request.Files[Save].FileName);

                int fileSize = Request.Files[Save].ContentLength;

                byte[] fileRcrd = new byte[fileSize];

                file_Strm.Read(fileRcrd, 0, fileSize);

                const string connect = @"Data Source=DESKTOP-J3NDKFP;Initial Catalog=ImagesDB;Integrated Security=True;";

                using (var conn = new SqlConnection(connect))

                {

                    var qry =
                        "INSERT INTO ImagesDB.dbo.Image (ImageRecord, ImageType, ImageName)VALUES (@ImageRecord, @ImageType, @ImageName)";

                    var cmd = new SqlCommand(qry, conn);

                    cmd.Parameters.AddWithValue("@ImageRecord", fileRcrd);

                    cmd.Parameters.AddWithValue("@ImageType", fileType);

                    cmd.Parameters.AddWithValue("@ImageName", file_Name);

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }

            }

            return View();
        }

        public ActionResult DownloadImage()

        {

            const string connect = @"Data Source=DESKTOP-J3NDKFP;Initial Catalog=ImagesDB;Integrated Security=True;";

            List<string> fileList = new List<string>();

            using (var con = new SqlConnection(connect))

            {

                var query = "SELECT ImageRecord, ImageType,ImageName FROM Image";

                var cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())

                {

                    fileList.Add(rdr["ImageName"].ToString());

                }

            }

            ViewBag.Images = fileList;

            return View();

        }

        public FileContentResult GetFile(int id)

        {

            SqlDataReader rdr;

            byte[] fileContent = null;

            string fileType = "";

            string file_Name = "";

            const string connect = @"Data Source=DESKTOP-J3NDKFP;Initial Catalog=ImagesDB;Integrated Security=True;";

            using (var con = new SqlConnection(connect))

            {

                var query = "SELECT ImageRecord, ImageType, ImageName FROM Image WHERE ImageID = @ImageID";

                var cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@ImageID", id);

                con.Open();

                rdr = cmd.ExecuteReader();

                if (rdr.HasRows)

                {

                    rdr.Read();

                    fileContent = (byte[])rdr["ImageRecord"];

                    fileType = rdr["Imagetype"].ToString();

                    file_Name = rdr["ImageName"].ToString();

                }

            }

            return File(fileContent, fileType, file_Name);

        }

    
    }
}
