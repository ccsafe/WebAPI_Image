using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Xml.Serialization;
using WebAPI_Image.Models;

namespace WebAPI_Image.Controllers
{
    /// <summary>
    /// 複数画像をbyte配列で取得し、jsonで返す
    /// </summary>
    public class MultiImageController : ApiController
    {
        // GET api/<controller>
        /// <summary>
        /// GET
        /// </summary>
        /// <returns>戻り値</returns>
        public HttpResponseMessage Get()
        //public ImagesInfo Get()
        {

            //画像のパスを取得
            var rootPath = HttpContext.Current.Server.MapPath("./");

            //画像データの取得
            var imgs = new ImagesInfo();
            imgs.Data.Add(ReadImageData(System.IO.Path.Combine(rootPath, @"images\test.png")));
            imgs.Data.Add(ReadImageData(System.IO.Path.Combine(rootPath, @"images\test2.png")));
            imgs.Number = imgs.Data.Count;

            //レスポンスの作成
            var res = new HttpResponseMessage();
            res.StatusCode = HttpStatusCode.OK;
            
            //TODO もっといい方法がないか？共通化できないか？
            //レスポンスをjsonかxmlどちらにするかを決定
            if(HttpContext.Current.Request.ContentType == "application/xml")
            {
                //レスポンス：XML
                using (var ms = new MemoryStream())
                {
                    var ser = new XmlSerializer(typeof(ImagesInfo));
                    ser.Serialize(ms, imgs);
                    res.Content = new StringContent(Encoding.UTF8.GetString(ms.ToArray()), Encoding.UTF8, "application/xml");
                }
            }
            else
            {
                //レスポンス：JSON
                res.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(imgs), Encoding.UTF8, "application/json");

            }

            return res;
        }

        /// <summary>
        /// 画像ファイルを読み込み、画像データを返す
        /// </summary>
        /// <param name="filePath">画像ファイルパス</param>
        /// <returns>画像データ</returns>
        private ImageData ReadImageData (string filePath)
        {

            var bmp = new Bitmap(filePath);
            byte[] img = null;
            using (var ms = new MemoryStream())
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                img = ms.GetBuffer();
            }

            //画像ファイル名と画像データを設定する
            var res = new ImageData();
            res.Name = System.IO.Path.GetFileNameWithoutExtension(filePath);
            res.PictImage = img;

            return res;
        }
    }
}
