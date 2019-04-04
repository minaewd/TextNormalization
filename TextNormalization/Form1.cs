using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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

            OpenFeileInText();
            // вывод нормализованного текста в соответствующее поле
            endText.Text = AppRegExp(startText.Text.ToLower());
            // вывод теста с измененными символами
            endText.Text = ChangeWord(endText.Text);
            SaveFileInText();
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

        void OpenFeileInText() //Открытие файла
        {
            openFileDialog1 = new OpenFileDialog();//Для выбора существующего файла
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";//Только для текстовых
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                startText.Text = File.ReadAllText(openFileDialog1.FileName, Encoding.Default);//Загрузка в текст бокс
            }
        }

        void SaveFileInText()//Сохранение файла
        {
            saveFileDialog1 = new SaveFileDialog();//Окно сохранения
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";//Маска для текстовых
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //StreamReader sr = new StreamReader(saveFileDialog1.FileName,Encoding.Default);//Поток для записи в файл из текст бокса
            
                if (endText.Text != "")
                {
                    //sr.Close();
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.Default);
                    sw.Write(endText.Text);
                    sw.Close();
                }
            }
    }

        string ChangeWord(string text) //дополнительная функциональность с заменой на похожие символы
        {
            string finalword = "";
            List<string> Words = new List<string>();
            Words.AddRange(text.Split(' '));
            GetRusSymbol();
            GetEngSymbol();
            GetUniSymbol();
            foreach (string word in Words)
            {
                if (GetLanguageWord(word).CompareTo("rus") == 0)
                {
                    
                    finalword += changeRusSymbol(word) + " ";
                    
                }
                else if (GetLanguageWord(word).CompareTo("eng") == 0)
                {
                    finalword += changeEngSymbol(word) + " ";
                    
                }
                else
                {
                    finalword += changeNumbSymbol(word) + " ";
                    
                }
            }

            return finalword;
        }

        string GetLanguageWord(string word)// получение языка слова
        {
            int engCount = 0;
            int rusCount = 0;
            int numCount = 0;
            foreach (char letter in word)
            {
                if ((letter >= 'а' && letter <= 'я') || (letter >= 'А' && letter <= 'Я'))
                    rusCount++;
                else if ((letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z'))
                    engCount++;
                else if ((letter >= '1' && letter <= '9') || (letter >= 'A' && letter <= 'Z'))
                    numCount++;
            }
            if ((rusCount >= engCount) && (rusCount >= numCount)) return "rus";
            if (engCount > numCount) return "eng"; 
            return "uni"; 
        }

        public class RusAdaption
        {
            public string rusAnalog;
            public string StartLatter;
        }

        List<RusAdaption> rusAnalog = new List<RusAdaption>();

        void GetRusSymbol() //Получение похожих на русские буквы символы и их русская адаптация
        {
            XDocument xdoc = XDocument.Load("Rus.xml");
            foreach (XElement phoneElement in xdoc.Element("rusLetters").Elements("letter"))
            {
                XElement rus = phoneElement.Element("rus");
                XElement an = phoneElement.Element("an");
                RusAdaption newEl = new RusAdaption();
                newEl.rusAnalog = rus.Value;
                newEl.StartLatter = an.Value;
                rusAnalog.Add(newEl);

            }
        }

        string GetElRus (char letter) //Получение аналога по букве
        {
            foreach (RusAdaption let in rusAnalog)
            {
                if (letter == let.StartLatter[0])
                {
                    letter = let.rusAnalog[0];
                    return letter + "";
                }
                    
            }
            return letter + "";
        }
        string changeRusSymbol(string word) //Смена похожих по начертанию символов в русском слове
        {
            string finalWord = "";
            string ChangeLatterRus = "";
            foreach (char c in word)
            {
                finalWord += GetElRus(c);
            }
            return finalWord;
        }

        public class EngAdaption
        {
            public string engAnalog;
            public string StartLatter;
        }

        List<EngAdaption> engAnalog = new List<EngAdaption>();

        void GetEngSymbol() //Получение похожих на английские буквы символы и их английская адаптация
        {
            XDocument xdoc = XDocument.Load("Eng.xml");
            foreach (XElement phoneElement in xdoc.Element("engLetters").Elements("letter"))
            {
                XElement eng = phoneElement.Element("eng");
                XElement an = phoneElement.Element("an");
                EngAdaption newEl = new EngAdaption();
                newEl.engAnalog = eng.Value;
                newEl.StartLatter = an.Value;
                engAnalog.Add(newEl);
            }
        }

        string changeEngSymbol(string word) // Смена похожих по начертанию символов в английском слове
        {
            string finalWord = "";
            foreach (char c in word)
            {
                finalWord += GetElEng(c);
            }
            return finalWord;
        }

        string GetElEng(char letter) //Получение аналога по букве
        {
            foreach (EngAdaption let in engAnalog)
            {
                if (letter == let.StartLatter[0])
                {
                    letter = let.engAnalog[0];
                    return letter + "";
                }

            }
            return letter + "";
        }


        public class NumAdaption
        {
            public string numAnalog;
            public string StartLatter;
        }

        List<NumAdaption> numAnalog = new List<NumAdaption>();

        void GetUniSymbol() //Получение похожих на цифры символы и их адаптация
        {
            XDocument xdoc = XDocument.Load("Num.xml");
            foreach (XElement phoneElement in xdoc.Element("numLetters").Elements("letter"))
            {
                XElement num = phoneElement.Element("num");
                XElement an = phoneElement.Element("an");
                NumAdaption newEl = new NumAdaption();
                newEl.numAnalog = num.Value;
                newEl.StartLatter = an.Value;
                numAnalog.Add(newEl);
            }
        }

        string changeNumbSymbol(string word)// Смена похожих по начертанию символов в числовом слове
        {
            string finalWord = "";
            foreach (char c in word)
            {
                finalWord += GetElEng(c);
            }
            return finalWord;
        }

        string GetElNumb(char letter) //Получение аналога по букве
        {
            foreach (NumAdaption let in numAnalog)
            {
                if (letter == let.StartLatter[0])
                {
                    letter = let.numAnalog[0];
                    return letter + "";
                }

            }
            return letter + "";
        }

    }
}
