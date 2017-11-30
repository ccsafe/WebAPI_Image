using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Image.Models
{
    /// <summary>
    /// 画像データ情報クラス
    /// </summary>
    public class ImagesInfo
    {
        /// <summary>
        /// 画像数
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 画像データのリスト
        /// </summary>
        public List<ImageData> Data { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ImagesInfo()
        {
            Data = new List<ImageData>();
        }
    }
}