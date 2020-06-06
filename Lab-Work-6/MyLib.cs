using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_Work_6
{
	class MyLib
	{
		/// <summary>
		/// Корректирует данные для ввода(целочисленные), если введено не число, возвращает 0.
		/// </summary>
		public static int CorrectInput(TextBox TextBox)
		{

			if (TextBox.Text != "")
			{


				if (IsNum(TextBox.Text))
				{
					int Value;
					Value = Convert.ToInt32(TextBox.Text);

					TextBox.Text = String.Format("{0}", Value);

					return Value;
				}
				else
				{
					TextBox.Text = "0";
				}
			}

			return 0;
		}

		static bool IsNum(string s) //Проверяем строчку состоит она из цифр или других символов
		{
			bool MinusCheck = false;
			if (s[0] == '-')
				MinusCheck = true;
			foreach (char c in s)
			{
				if (!Char.IsDigit(c) && MinusCheck == false) return false;
			}
			return true;
		}
	}
}
