using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_Work_6
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			listBox1.Items.Clear(); // освобождаем listBox1
			textBox2.Clear(); // освобождаем textBox2
			textBox3.Clear(); // освобождаем textBox3
			textBox4.Clear(); // освобождаем textBox4
			listBox1.Sorted = false; // выключаем автоматическую сортировку в listBox1
			int n = MyLib.CorrectInput(textBox1);// получаем числовое значение из textBox1
			if (n < 1) // проверка допустимости значения, введенного пользователем
			{
				n = 1;
				textBox1.Text = String.Format("{0}", n);// замена значения, введенного в textBox1
			}
			Random r = new Random(); //создаем объект для работы с псевдослучайными числами
			for (int i = 0; i < n; i++) // цикл для записи n элементов
				listBox1.Items.Add(r.Next(-500, 500));//добавление в listBox1 строки, содержащей число 
			button2.Enabled = true; // делаем активной кнопку button2
			button3.Enabled = true; // делаем активной кнопку button3
			button4.Enabled = true; // делаем активной кнопку button4
			button5.Enabled = true; // делаем активной кнопку button5
			button6.Enabled = true; // делаем активной кнопку button6
			button7.Enabled = true; // делаем активной кнопку button7
			button8.Enabled = true; // делаем активной кнопку button8
			button9.Enabled = true; // делаем активной кнопку button9
			button10.Enabled = true; // делаем активной кнопку button10
			button11.Enabled = true; // делаем активной кнопку button11
			BtnSave.Enabled = true; // делаем активной кнопку BtnSave
			listBox1.SelectedIndex = -1; // убираем выделение со всех элементов списка
			MessageBox.Show("Массив случайных чисел сформирован", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
			// выводим окно с сообщением 

		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedIndex == -1) // проверка отсутствия выделения строки в списке
				textBox2.Text = "Выберите элемент массива";// выводим сообщение в textBox2
			else
				// выводим выделенный элемент списка в textBox2
				textBox2.Text = listBox1.SelectedItem.ToString();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedIndex == -1) // проверка отсутствия выделения строки в списке
				MessageBox.Show("Выберите элемент массива", "Данные не введены", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // выводим сообщение в окно MessageBox
			else
			{
				listBox1.Items.RemoveAt(listBox1.SelectedIndex); // удаляем выделенную строку  
				textBox2.Clear(); // освобождаем textBox2
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (textBox3.Text.Length == 0) // проверка длины строки в textBox3  
				MessageBox.Show("Введите число", "Данные не введены", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // вывод сообщения
			else
			{
				listBox1.Items.Insert(0, textBox3.Text); // вставка строки в listBox1
				listBox1.SelectedIndex = 0; // убираем выделение элементов в listBox1
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			bool flag = false; // обнуляем флаг, который определяет результативность поиска 
			for (int i = 0; i < listBox1.Items.Count; i++) // цикл проверки всех строк в listBox1
				if (listBox1.Items[i].ToString() == textBox4.Text) // условие проверки на совпадение 
				{
					listBox1.SelectedIndex = i; // выделяем найденную строку
					string s = string.Format("Найденное значение выделено, его индекс = {0}", listBox1.SelectedIndex); // формируем строку для вывода
					MessageBox.Show(s, "Элемент найден", MessageBoxButtons.OKCancel); // выводим сообщение
					flag = true; // "поднимаем" флаг, т.е. фиксируем, что пользователь получил результат
				}
			if (flag) // проверка значения флага
			{
				MessageBox.Show("В массиве нет элемента со значением " + textBox4.Text, "Элемент не найден"); // вывод сообщения
				listBox1.SelectedIndex = -1; // убираем выделение элементов в списке
			}

		}

		private void button6_Click(object sender, EventArgs e)
		{
			listBox1.Sorted = false;//отключаем автоматическую сортировку listBox1 по алфавиту
									// создаем массив, размер которого равен количеству элементов в listBox1
			int[] a = new int[listBox1.Items.Count];
			for (int i = 0; i < listBox1.Items.Count; i++)// цикл перебора всех элементов в listBox1
				a[i] = Convert.ToInt32(listBox1.Items[i]); // конвертируем элемент из listBox1 в число
			Array.Sort(a); // сортируем массив а[], используя метод класса Array
			for (int i = 0; i < listBox1.Items.Count; i++)// цикл перебора всех элементов в listBox1
														  // в i-тый элемент listBox1 присваиваем строковое представление числа а[i]
				listBox1.Items[i] = string.Format("{0}", a[i]);
			MessageBox.Show("Одномерный числовой массив в элементе ListBox упорядочен", "Сортировка чисел");// выводим сообщение
		}

		private void button7_Click(object sender, EventArgs e)
		{
			{// включаем автоматическую сортировку элементов объекта listBox1 по алфавиту
				listBox1.Sorted = true;
				// выводим сообщение о завершении сортировки
				MessageBox.Show("Массив строк в элементе ListBox упорядочен", "Сортировка строк");
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			int[] a = new int[listBox1.Items.Count];    // создаем массив, размер которого равен количеству элементов в listBox1

			int CountNegativeElements=0;

			for (int i = 0; i < listBox1.Items.Count; i++)// цикл перебора всех элементов в listBox1
				a[i] = Convert.ToInt32(listBox1.Items[i]); // конвертируем элемент из listBox1 в число

			for (int i = 0; i < a.Length; i++)
			{
				if (a[i] < 0)
				{
					CountNegativeElements++;
				}
			}
			bool repeat = false;
			foreach (string line in textBox5.Lines)
			{
				if (line == "Кол-во отрицательных элементов в массиве:" + CountNegativeElements)
				{
					repeat = true;
					break;
				}
					
			}
			if(repeat==false)
				textBox5.Text += "\nКол-во отрицательных элементов в массиве:" + CountNegativeElements;
			MessageBox.Show("Кол-во отрицательных элементов в массиве:" + CountNegativeElements,"Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void button8_Click(object sender, EventArgs e)
		{
			int[] a = new int[listBox1.Items.Count];    // создаем массив, размер которого равен количеству элементов в listBox1

			int MaxElement;

			for (int i = 0; i < listBox1.Items.Count; i++)// цикл перебора всех элементов в listBox1
				a[i] = Convert.ToInt32(listBox1.Items[i]); // конвертируем элемент из listBox1 в число

			MaxElement = a[0];
			for (int i = 0; i < a.Length; i++)
			{
				if (a[i] > MaxElement)
				{
					MaxElement = a[i];
				}
			}
			bool repeat = false;
			foreach (string line in textBox5.Lines)
			{
				if (line == "Максимальный элемент:" + MaxElement)
				{
					repeat = true;
					break;
				}
			}
			if (repeat == false)
				textBox5.Text += "\nМаксимальный элемент:" + MaxElement;
			MessageBox.Show("Максимальный элемент:" + MaxElement, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void button11_Click(object sender, EventArgs e)
		{
			int[] a = new int[listBox1.Items.Count];    // создаем массив, размер которого равен количеству элементов в listBox1

			int CountOddElements=0;

			for (int i = 0; i < listBox1.Items.Count; i++)// цикл перебора всех элементов в listBox1
				a[i] = Convert.ToInt32(listBox1.Items[i]); // конвертируем элемент из listBox1 в число

			for(int i = 0; i < a.Length; i++)
			{
				if (a[i] % 2 != 0)
				{
					CountOddElements++;
				}
			}
			bool repeat = false;
			foreach (string line in textBox5.Lines)
			{
				if (line == "Кол-во нечётных:" + CountOddElements)
				{
					repeat = true;
					break;
				}
					
			}
			if (repeat == false)
				textBox5.Text += "\nКол-во нечётных:" + CountOddElements;
			MessageBox.Show("Кол-во нечётных:" + CountOddElements, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void button10_Click(object sender, EventArgs e)
		{
			int[] a = new int[listBox1.Items.Count];    // создаем массив, размер которого равен количеству элементов в listBox1

			int SumElements=0;

			for (int i = 0; i < listBox1.Items.Count; i++)// цикл перебора всех элементов в listBox1
				a[i] = Convert.ToInt32(listBox1.Items[i]); // конвертируем элемент из listBox1 в число

			for (int i = 0; i < a.Length; i++)
			{
				if (a[i] > 0)
				{
					SumElements += a[i];
				}
			}
			bool repeat = false;
			foreach (string line in textBox5.Lines)
			{
				if (line == "Сумма положительных чисел: " + SumElements)
				{
					repeat = true;
					break;
				}

			}
			if (repeat == false)
				textBox5.Text += "\nСумма положительных чисел: " + SumElements;
			MessageBox.Show("Сумма положительных чисел: " + SumElements, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();// Создаем диалоговое окно для открытия файла
			sfd.Title = "Выберите файл для записи массива";//задаем заголовок диалогового окна
			sfd.InitialDirectory = @"C:\";// задаем начальный путь для сохранения файла
										  // Создаем фильтр для отображаемых типов файлов
			sfd.Filter = "txt file (*.txt)|*.txt|all files (*.*)|*.*";

			// открываем окно для сохранения файла командой sfd.ShowDialog() 
			//и проверяем, нажата ли кнопка "Сохранить" в этом окне, т.е.достигнут ли результат "ОК"
			if (sfd.ShowDialog() == DialogResult.OK)
			{// открываем файл для записи (дозапись исключена)
				using (StreamWriter sw = new StreamWriter(sfd.FileName))
				{
					sw.WriteLine("Исходный массив:");
					foreach (var item in listBox1.Items)// цикл по всем строкам в textBox2
					{
						int x = Convert.ToInt32(item);
						sw.WriteLine(x);
					}
					sw.Write("Ваш массив содержит следующие характеристики:");
					if (textBox5.Text == "")
						sw.WriteLine("Пусто...");
					sw.WriteLine(textBox5.Text);
					MessageBox.Show("Файл сохранён!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}
	}
}
