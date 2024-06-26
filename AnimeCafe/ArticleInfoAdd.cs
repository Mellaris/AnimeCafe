using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeCafe
{
    public class ArticleInfoAdd
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tema { get; set; }
        public string Start {  get; set; }
        public string Date {  get; set; }
        public string fileName { get; set; }
        public Bitmap ArticleImage
        {
            get
            {
                return new Bitmap(fileName);
            }
            set { }
        }
        public int idArticle {  get; set; }
        public int idEdit {  get; set; }
    }

}
