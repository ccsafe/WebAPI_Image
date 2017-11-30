using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Image.Models
{


    /// <summary>
    /// 画像データ情報クラス
    /// </summary>
    public class ImageData
    {
        /// <summary>画像ファイルの名称</summary>
        public string Name { get; set; }

        /// <summary>画像データ</summary>
        public byte[] PictImage { get; set; }

        public ImageData() { }

        

    }

}