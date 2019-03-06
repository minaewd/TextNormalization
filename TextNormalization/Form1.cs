using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextNormalization
{
    public partial class FormNormalization : Form
    {
        public FormNormalization()
        {
            InitializeComponent();
        }

        private void NormalizationButton_Click(object sender, EventArgs e)
        {
            // вывод нормализованного текста в соответствующее поле
            endText.Text = AppRegExp(startText.Text.ToLower());
        }

        private static string AppRegExp(string text)
        {
            // строка результата
            string res_text = "";

            // задание регулярных выражений для обработки входной строки
            Regex regex = new Regex(@"\W"); // убирает не буквенно-цифровые символы
            Regex regex3 = new Regex(@"\s\s+"); // убирает лишние пробелы
            
            // применение регулярных выражений к исходной строке
            res_text = regex.Replace(text, " ");
            res_text = res_text.Replace("_", " ");
            res_text = regex3.Replace(res_text, " ");

            return res_text;
        }

    }
}
