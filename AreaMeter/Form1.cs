using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace AreaMeter
{
	public partial class Form1 : Form
	{
		SolidBrush myBrush = new SolidBrush(Color.Blue);
		Graphics myGraf;
		Bitmap bmp;
		Point[] pos;
		Point[] posNotScale;
		Pos newPos;
		List<Pos> PosArray;
		List<Pos> PosArrayNotScale;
		DataTable myDataTable = new DataTable("myDataTable");
		DataTable myDataTableCopy = new DataTable("myDataTableCopy");
		Color cellBackColor;
		Color formBackColor;
		List<ErrorCell> ErrorCellArray = new List<ErrorCell>();
		DialogResult result = DialogResult.Cancel;
		bool res;
		bool drawPanel = false;
		Timer timerTurn = new Timer();
		Timer timerScale = new Timer();
		bool butTimeR;
		bool butScaleR;
		float myScale = 100;
		float oldScale;
		bool changeScale;
		float myTurn = 0;
		float oldTurn;
		bool changeTurn;
		bool CreateMyTableSuccess;
		bool CreateImageSuccess;
		bool KeyBack;
		int delRow;
		bool rowDel;
		bool rowIns;
		bool rowInsWithMouse;
		bool tableClear;
		bool createImage;
		List<Point> ListPoint = new List<Point>();
		Pen penLines = new Pen(Color.FromArgb(25, 225, 0), 2);
		Graphics graphLines;
		bool textSquareKeyPressBOOL;
		bool changeValue;
		bool chTurn;
		int RowForMoveTop;
		bool MoveTop;
		bool moveTop;
		bool keyInsert;
		bool keyDelete;
		bool RLF = false; byte RL = 0;
		bool RAF = false; byte RA = 0;
		bool keyCTRL;
		bool openFile; // Наверное не нужно
		bool cellValue;
		int rowPeresech_1 = -1;
		int rowPeresech_2 = -1;

		int Length_Square_pixel = 500;
		//uint Area_Square_pixel;
		float Length_Square_metre;
		float OldLength;
		float Length_Square_metreScale;
		//float Area_Square_metre;
		//uint Area_Figure_pixel;
		float Area_Figure_metre;
		float[,] MyTable;
		float[,] MyTableCopy;
		float[,] MyTableScale;
		float[,] MyTableRev;
		float[,] MyTableRevScale;
		float[,] MyTableLines;

		public Form1()
		{
			InitializeComponent();
			CreateDataTable();
			dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
			dataGridView1.CellLeave += new DataGridViewCellEventHandler(dataGridView1_CellLeave);
			dataGridView1.CellEnter += new DataGridViewCellEventHandler(dataGridView1_CellEnter);
			dataGridView1.DataError += new DataGridViewDataErrorEventHandler(dataGridView1_DataError);
			dataGridView1.KeyUp += new KeyEventHandler(dataGridView1_KeyUp);
			dataGridView1.KeyDown += new KeyEventHandler(dataGridView1_KeyDown);
			buttonLeft.PreviewKeyDown += new PreviewKeyDownEventHandler(buttonLeft_PreviewKeyDown);
			buttonRight.PreviewKeyDown += new PreviewKeyDownEventHandler(buttonRight_PreviewKeyDown);
			buttonLeft.KeyUp += new KeyEventHandler(buttonLeft_KeyUp);
			buttonRight.KeyUp += new KeyEventHandler(buttonRight_KeyUp);
			buttonLeft.MouseDown += new MouseEventHandler(buttonLeft_MouseDown);
			buttonRight.MouseDown += new MouseEventHandler(buttonRight_MouseDown);
			buttonLeft.MouseUp += new MouseEventHandler(buttonLeft_MouseUp);
			buttonRight.MouseUp += new MouseEventHandler(buttonRight_MouseUp);
			textTurn.KeyPress += new KeyPressEventHandler(textTurn_KeyPress);
			timerTurn.Interval = 100;
			timerTurn.Tick += new EventHandler(timer_Tick);
			timerScale.Interval = 100;
			timerScale.Tick += new EventHandler(timerScale_Tick);
			textScale.KeyPress += new KeyPressEventHandler(textScale_KeyPress);
			butScaleMin.PreviewKeyDown += new PreviewKeyDownEventHandler(butScaleMin_PreviewKeyDown);
			butScaleMax.PreviewKeyDown += new PreviewKeyDownEventHandler(butScaleMax_PreviewKeyDown);
			butScaleMin.KeyUp += new KeyEventHandler(butScaleMin_KeyUp);
			butScaleMax.KeyUp += new KeyEventHandler(butScaleMax_KeyUp);
			butScaleMin.MouseDown += new MouseEventHandler(butScaleMin_MouseDown);
			butScaleMax.MouseDown += new MouseEventHandler(butScaleMax_MouseDown);
			butScaleMin.MouseUp += new MouseEventHandler(butScaleMin_MouseUp);
			butScaleMax.MouseUp += new MouseEventHandler(butScaleMax_MouseUp);
			dataGridView1.CurrentCellChanged += new EventHandler(dataGridView1_CurrentCellChanged);
			pictureBox1.MouseClick += new MouseEventHandler(pictureBox1_MouseClick);
			pictureBox1.MouseDoubleClick += new MouseEventHandler(pictureBox1_MouseDoubleClick);
			pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
			pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
			pictureBox1.MouseUp += new MouseEventHandler(pictureBox1_MouseUp);
			pictureBox1.MouseEnter += new EventHandler(pictureBox1_MouseEnter);
			pictureBox1.MouseLeave += new EventHandler(pictureBox1_MouseLeave);
			graphLines = Graphics.FromHwnd(pictureBox1.Handle);
			this.KeyDown += new KeyEventHandler(Form1_KeyDown);
			this.KeyUp += new KeyEventHandler(Form1_KeyUp);
			this.Paint += new PaintEventHandler(Form1_Paint);
			formBackColor = this.BackColor;
		}

		void CreateDataTable()
		{
			#region Создаем объекты DataColumn
			DataColumn myDataColumn0;
			myDataColumn0 = new DataColumn("No", typeof(ushort));
			myDataColumn0.ReadOnly = true;
			myDataColumn0.Caption = "No";
			myDataColumn0.AllowDBNull = false;
			myDataColumn0.Unique = true;
			myDataColumn0.AutoIncrement = true;
			myDataColumn0.AutoIncrementSeed = 1;
			myDataColumn0.AutoIncrementStep = 1;
			DataColumn myDataColumn0Copy;
			myDataColumn0Copy = new DataColumn("NoCopy", typeof(ushort));
			myDataColumn0Copy.ReadOnly = true;
			myDataColumn0Copy.Caption = "No";
			myDataColumn0Copy.AllowDBNull = false;
			myDataColumn0Copy.Unique = true;
			myDataColumn0Copy.AutoIncrement = true;
			myDataColumn0Copy.AutoIncrementSeed = 1;
			myDataColumn0Copy.AutoIncrementStep = 1;
			DataColumn myDataColumn1 = new DataColumn("Азимут", typeof(float));
			myDataColumn1.AllowDBNull = true;
			DataColumn myDataColumn1Copy = new DataColumn("АзимутCopy", typeof(float));
			myDataColumn1Copy.AllowDBNull = true;
			DataColumn myDataColumn2 = new DataColumn("Длина", typeof(float));
			myDataColumn2.AllowDBNull = true;
			DataColumn myDataColumn2Copy = new DataColumn("ДлинаCopy", typeof(float));
			myDataColumn2Copy.AllowDBNull = true;
			#endregion
			myDataTable.Columns.AddRange(new DataColumn[] { myDataColumn0, myDataColumn1, myDataColumn2 });
			myDataTable.PrimaryKey = new DataColumn[] { myDataTable.Columns["No"] };
			myDataTableCopy.Columns.AddRange(new DataColumn[] { myDataColumn0Copy, myDataColumn1Copy, myDataColumn2Copy });
			myDataTableCopy.PrimaryKey = new DataColumn[] { myDataTable.Columns["NoCopy"] };
			dataSet1.DataSetName = "myDataSet";
			dataSet1.Tables.Add(myDataTable);
			dataGridView1.DataSource = dataSet1;
			dataGridView1.DataMember = myDataTable.TableName;
			dataGridView1.MultiSelect = false;
			dataGridView1.Columns[myDataColumn0.ColumnName].Visible = false;
			dataGridView1.Columns[myDataColumn1.ColumnName].HeaderText = "Азимут в диапазоне (0; 360( град";
			dataGridView1.Columns[myDataColumn1.ColumnName].Width = 75;
			dataGridView1.Columns[myDataColumn1.ColumnName].SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridView1.Columns[myDataColumn2.ColumnName].HeaderText = "Длина, м";
			dataGridView1.Columns[myDataColumn2.ColumnName].SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridView1.Columns[myDataColumn2.ColumnName].Width = 117;
			cellBackColor = dataGridView1[0, 0].Style.BackColor;
		}

		private bool CreateMyTable()
		{
			float Az;
			try
			{
				for (int i = 0; i < myDataTable.Rows.Count; i++)
					if (myDataTable.Rows[i][1].ToString() == "" && myDataTable.Rows[i][2].ToString() == "")
						myDataTable.Rows[i].Delete();

				MyTable = new float[myDataTable.Rows.Count + 1, myDataTable.Columns.Count - 1];
				MyTable[0, 0] = 0; MyTable[0, 1] = 0;
				//Формируем координаты (X, Y) отдельно заданных точек
				for (int i = 1; i < MyTable.GetLength(0); i++)
				{
					if ((float)myDataTable.Rows[i - 1][1] == 0)
					{
						MyTable[i, 0] = 0;
						MyTable[i, 1] = (float)myDataTable.Rows[i - 1][2];
					}
					if ((float)myDataTable.Rows[i - 1][1] > 0 && (float)myDataTable.Rows[i - 1][1] < 90)
					{
						MyTable[i, 0] = (float)myDataTable.Rows[i - 1][2] * (float)Math.Sin((float)myDataTable.Rows[i - 1][1] * Math.PI / 180);
						MyTable[i, 1] = (float)myDataTable.Rows[i - 1][2] * (float)Math.Cos((float)myDataTable.Rows[i - 1][1] * Math.PI / 180);
					}
					if ((float)myDataTable.Rows[i - 1][1] == 90)
					{
						MyTable[i, 0] = (float)myDataTable.Rows[i - 1][2];
						MyTable[i, 1] = 0;
					}
					if ((float)myDataTable.Rows[i - 1][1] > 90 && (float)myDataTable.Rows[i - 1][1] < 180)
					{
						Az = (float)myDataTable.Rows[i - 1][1] - 90;
						MyTable[i, 0] = (float)myDataTable.Rows[i - 1][2] * (float)Math.Cos(Az * Math.PI / 180);
						MyTable[i, 1] = -(float)myDataTable.Rows[i - 1][2] * (float)Math.Sin(Az * Math.PI / 180);
					}
					if ((float)myDataTable.Rows[i - 1][1] == 180)
					{
						MyTable[i, 0] = 0;
						MyTable[i, 1] = -(float)myDataTable.Rows[i - 1][2];
					}
					if ((float)myDataTable.Rows[i - 1][1] > 180 && (float)myDataTable.Rows[i - 1][1] < 270)
					{
						Az = (float)myDataTable.Rows[i - 1][1] - 180;
						MyTable[i, 0] = -(float)myDataTable.Rows[i - 1][2] * (float)Math.Sin(Az * Math.PI / 180);
						MyTable[i, 1] = -(float)myDataTable.Rows[i - 1][2] * (float)Math.Cos(Az * Math.PI / 180);
					}
					if ((float)myDataTable.Rows[i - 1][1] == 270)
					{
						MyTable[i, 0] = -(float)myDataTable.Rows[i - 1][2];
						MyTable[i, 1] = 0;
					}
					if ((float)myDataTable.Rows[i - 1][1] > 270 && (float)myDataTable.Rows[i - 1][1] < 360)
					{
						Az = 360 - (float)myDataTable.Rows[i - 1][1];
						MyTable[i, 0] = -(float)myDataTable.Rows[i - 1][2] * (float)Math.Sin(Az * Math.PI / 180);
						MyTable[i, 1] = (float)myDataTable.Rows[i - 1][2] * (float)Math.Cos(Az * Math.PI / 180);
					}
				}
				//Формируем из совокупности отдельных точек
				//взаимосвязанные координаты вершин многоугольника на декартовой плоскости
				for (int i = 1; i < MyTable.GetLength(0); i++)
				{
					MyTable[i, 0] = MyTable[i, 0] + MyTable[i - 1, 0];
					MyTable[i, 1] = MyTable[i, 1] + MyTable[i - 1, 1];
				}

				//В данном месте делаем копию таблицы для параллельного использования при масштабировании
				//и возможности возвращения к первоначальному масштабу
				MyTableCopy = new float[MyTable.GetLength(0), MyTable.GetLength(1)];
				for (int i = 0; i < MyTableCopy.GetLength(0); i++)
					for (int j = 0; j < MyTableCopy.GetLength(1); j++)
						MyTableCopy[i, j] = MyTable[i, j];
				Length_Square_metreScale = Length_Square_metre;

				//Находим минимальные и максимальные координаты по осям X и Y
				float MinX, MinY, MaxX, MaxY;
				MinX = MinY = MaxX = MaxY = 0;
				for (int i = 0; i < MyTable.GetLength(0); i++)
				{
					if (MyTable[i, 0] < MinX)
						MinX = MyTable[i, 0];
					if (MyTable[i, 0] > MaxX)
						MaxX = MyTable[i, 0];
					if (MyTable[i, 1] < MinY)
						MinY = MyTable[i, 1];
					if (MyTable[i, 1] > MaxY)
						MaxY = MyTable[i, 1];
				}
				//Находим длину фигуры по осям X и Y
				//Если существуют отрицательные координаты,
				//то выполняем параллельный перенос фигуры в первую декартовую полуплоскость
				//При этом размещаем фигуру в центре внешнего квадрата.
				//ВНИМАНИЕ!!! В таблице MyTable сейчас формируются окончательные вершины многоугольника,
				//расположенного по центру первой декартовой полуплоскости.
				//Вершины расположены строго по порядку по ходу часовой стрелки!
				float LengthX, LengthY, PerenX, PerenY;
				if (MinX < 0)
				{
					LengthX = Math.Abs(MinX) + MaxX;
					PerenX = (Length_Square_metre - LengthX) / 2;
					for (int i = 0; i < MyTable.GetLength(0); i++)
						MyTable[i, 0] = MyTable[i, 0] + Math.Abs(MinX) + PerenX;
				}
				else
				{
					LengthX = MaxX;
					PerenX = (Length_Square_metre - LengthX) / 2;
					for (int i = 0; i < MyTable.GetLength(0); i++)
						MyTable[i, 0] = MyTable[i, 0] + PerenX;
				}
				if (MinY < 0)
				{
					LengthY = Math.Abs(MinY) + MaxY;
					PerenY = (Length_Square_metre - LengthY) / 2;
					for (int i = 0; i < MyTable.GetLength(0); i++)
						MyTable[i, 1] = MyTable[i, 1] + Math.Abs(MinY) + PerenY;
				}
				else
				{
					LengthY = MaxY;
					PerenY = (Length_Square_metre - LengthY) / 2;
					for (int i = 0; i < MyTable.GetLength(0); i++)
						MyTable[i, 1] = MyTable[i, 1] + PerenY;
				}
				//Выполняем перенос точки начала отсчёта (0, 0)
				//из левого нижнего угла экрана в левый верхний угол
				MyTableRev = new float[myDataTable.Rows.Count + 1, myDataTable.Columns.Count - 1];
				for (int i = 0; i < MyTable.GetLength(0); i++)
				{
					MyTableRev[i, 0] = MyTable[i, 0];
					MyTableRev[i, 1] = Length_Square_metre - MyTable[i, 1];
				}

				//Выполняем проверку того, что наша фигура помещается в заданный внешний квадрат			
				if (LengthX > Length_Square_metre)
				{					
					timerTurn.Stop();
					if (!MoveTop)
					{						
						if (RL == 0)
							result = MessageBox.Show("Данные не могут быть введены!\nРазмер фигуры по горизонтали составляет " + LengthX + ", м\nЭто превышает длину стороны внешнего квадрата", "Ошибка пользователя", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						if (keyDelete)
						{
							RLF = true;
						}
						if (RLF)
							RL++;
						if (RL == 4)
						{
							RLF = false;
							RL = 0;
						}
					}
					if ((changeTurn || MoveTop) && !keyDelete)
					{
						if (MoveTop)
							changeValue = false;
						createImage = true;
						myDataTable.Rows.Clear();
						for (int i = 0; i < myDataTableCopy.Rows.Count; i++)
						{
							DataRow newRow = myDataTable.NewRow();
							myDataTable.Rows.Add(newRow);
							myDataTable.Rows[i][1] = myDataTableCopy.Rows[i][1];
							myDataTable.Rows[i][2] = myDataTableCopy.Rows[i][2];
						}
						textTurn.Text = oldTurn.ToString();
						myTurn = oldTurn;
						createImage = false;
					}
					else if (!textSquareKeyPressBOOL)
						Clear();
					if (MoveTop)
						moveTop = true;
					MoveTop = false;
					return false;
				}
				if (LengthY > Length_Square_metre)
				{
					timerTurn.Stop();
					if (!MoveTop)
					{
						if (RA == 0)
							result = MessageBox.Show("Данные не могут быть введены!\nРазмер фигуры по вертикали составляет " + LengthY + ", м\nЭто превышает длину стороны внешнего квадрата", "Ошибка пользователя", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						if (keyDelete)
						{
							RAF = true;
						}
						if (RAF)
							RA++;
						if (RA == 4)
						{
							RAF = false;
							RA = 0;
						}
					}
					if ((changeTurn || MoveTop) && !keyDelete)
					{
						if (MoveTop)
							changeValue = false;
						createImage = true;
						myDataTable.Rows.Clear();
						for (int i = 0; i < myDataTableCopy.Rows.Count; i++)
						{
							DataRow newRow = myDataTable.NewRow();
							myDataTable.Rows.Add(newRow);
							myDataTable.Rows[i][1] = myDataTableCopy.Rows[i][1];
							myDataTable.Rows[i][2] = myDataTableCopy.Rows[i][2];
						}
						textTurn.Text = oldTurn.ToString();
						myTurn = oldTurn;
						createImage = false;
					}
					else if (!textSquareKeyPressBOOL)
						Clear();
					if (MoveTop)
						moveTop = true;
					MoveTop = false;
					return false;
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		void Square()
		{
			try
			{
				if (!rowDel)
				{
					if (rowPeresech_1 != -1 && rowPeresech_2 != -1)
					{
						dataGridView1.Rows[rowPeresech_1].DefaultCellStyle.BackColor = cellBackColor;
						dataGridView1.Rows[rowPeresech_2].DefaultCellStyle.BackColor = cellBackColor;
						rowPeresech_1 = -1; rowPeresech_2 = -1;
					}

					MyTableLines = new float[MyTable.GetLength(0) + 1, MyTable.GetLength(1)];
					for (int i = 0; i < MyTableLines.GetLength(0); i++)
						if (i != MyTableLines.GetUpperBound(0))
						{
							MyTableLines[i, 0] = MyTable[i, 0];
							MyTableLines[i, 1] = MyTable[i, 1];
						}
						else
						{
							MyTableLines[i, 0] = MyTable[0, 0];
							MyTableLines[i, 1] = MyTable[0, 1];
						}

					float znamenatel, chislitelUA, chislitelUB;
					float x1, y1, x2, y2, x3, y3, x4, y4;
					const float eps = 0.001F;
					for (int i = 0; i <= MyTableLines.GetUpperBound(0) - 2; i++)
						for (int j = i + 1; j <= MyTableLines.GetUpperBound(0) - 1; j++)
						{
							x1 = MyTableLines[i, 0]; y1 = MyTableLines[i, 1];
							x2 = MyTableLines[i + 1, 0]; y2 = MyTableLines[i + 1, 1];
							x3 = MyTableLines[j, 0]; y3 = MyTableLines[j, 1];
							x4 = MyTableLines[j + 1, 0]; y4 = MyTableLines[j + 1, 1];
							znamenatel = (y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1);
							chislitelUA = (x4 - x3) * (y1 - y3) - (y4 - y3) * (x1 - x3);
							chislitelUB = (x2 - x1) * (y1 - y3) - (y2 - y1) * (x1 - x3);

							if (Math.Abs(znamenatel) <= eps && Math.Abs(chislitelUA) <= eps && Math.Abs(chislitelUB) <= eps)
							{
								float Y1, Y2, Y3, Y4, X1, X2, X3, X4;
								float Y1f, Y2f, Y3f, Y4f, X1f, X2f, X3f, X4f;
								if (Math.Abs(x1 - x3) <= eps)
								{
									if (y1 < y2)
									{ Y1 = y1; Y2 = y2; }
									else
									{ Y1 = y2; Y2 = y1; }
									if (y3 < y4)
									{ Y3 = y3; Y4 = y4; }
									else
									{ Y3 = y4; Y4 = y3; }
									if (Y1 < Y3)
									{ Y1f = Y1; Y2f = Y2; Y3f = Y3; Y4f = Y4; }
									else
									{ Y1f = Y3; Y2f = Y4; Y3f = Y1; Y4f = Y2; }
									if (Y3f < Y2f)
									{
										labelSquare2.Text = "Наложение";
										labelSquare2.ForeColor = Color.OrangeRed;
										rowPeresech_1 = i; rowPeresech_2 = j;
										dataGridView1.Rows[rowPeresech_1].DefaultCellStyle.BackColor = Color.DarkOrange;
										dataGridView1.Rows[rowPeresech_2].DefaultCellStyle.BackColor = Color.DarkOrange;
										bool last = false;
										if (j == MyTableLines.GetUpperBound(0) - 1)
											last = true;
										LinesPeresech(i, j, last);
										return;
									}
								}
								else
								{
									if (x1 < x2)
									{ X1 = x1; X2 = x2; }
									else
									{ X1 = x2; X2 = x1; }
									if (x3 < x4)
									{ X3 = x3; X4 = x4; }
									else
									{ X3 = x4; X4 = x3; }
									if (X1 < X3)
									{ X1f = X1; X2f = X2; X3f = X3; X4f = X4; }
									else
									{ X1f = X3; X2f = X4; X3f = X1; X4f = X2; }
									if (X3f < X2f)
									{
										labelSquare2.Text = "Наложение";
										labelSquare2.ForeColor = Color.OrangeRed;
										rowPeresech_1 = i; rowPeresech_2 = j;
										dataGridView1.Rows[rowPeresech_1].DefaultCellStyle.BackColor = Color.DarkOrange;
										dataGridView1.Rows[rowPeresech_2].DefaultCellStyle.BackColor = Color.DarkOrange;
										bool last = false; ;
										if (j == MyTableLines.GetUpperBound(0) - 1)
											last = true;
										LinesPeresech(i, j, last);
										return;
									}
								}
							}

							if (Math.Abs(znamenatel) > eps)
							{
								float UA = chislitelUA / znamenatel;
								float UB = chislitelUB / znamenatel;
								if (0 + eps < UA && UA < 1 - eps && 0 + eps < UB && UB < 1 - eps)
								{
									labelSquare2.Text = "Пересечение";
									labelSquare2.ForeColor = Color.OrangeRed;
									rowPeresech_1 = i; rowPeresech_2 = j;
									dataGridView1.Rows[rowPeresech_1].DefaultCellStyle.BackColor = Color.DarkOrange;
									dataGridView1.Rows[rowPeresech_2].DefaultCellStyle.BackColor = Color.DarkOrange;
									bool last = false;
									if (j == MyTableLines.GetUpperBound(0) - 1)
										last = true;
									LinesPeresech(i, j, last);
									return;
								}
							}
						}
				}

				for (uint i = 0; i < MyTable.GetLength(0); i++)
				{
					if (i == 0)
						Area_Figure_metre = MyTable[i, 1] * (MyTable[i + 1, 0] - MyTable[MyTable.GetUpperBound(0), 0]);
					else if (i == MyTable.GetUpperBound(0))
						Area_Figure_metre = (Area_Figure_metre + MyTable[i, 1] * (MyTable[0, 0] - MyTable[i - 1, 0])) / 2;
					else
						Area_Figure_metre = Area_Figure_metre + MyTable[i, 1] * (MyTable[i + 1, 0] - MyTable[i - 1, 0]);
				}
				labelSquare2.Text = Math.Round(Math.Abs(Area_Figure_metre), 2).ToString();
				labelSquare2.ForeColor = Color.Blue;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n\nРЕКОМЕНДУЕТСЯ СОХРАНИТЬ ВСЕ ДАННЫЕ И ПЕРЕЗАГРУЗИТЬ ПРОГРАММУ!", "Ошибка программы", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void LinesPeresech(int i, int j, bool last)
		{
			int Line_1_X1, Line_1_Y1, Line_1_X2, Line_1_Y2, Line_2_X1, Line_2_Y1, Line_2_X2, Line_2_Y2;
			Line_1_X1 = pos[i].X;
			Line_1_Y1 = pos[i].Y;
			Line_1_X2 = pos[i + 1].X;
			Line_1_Y2 = pos[i + 1].Y;
			if (!last)
			{
				Line_2_X1 = pos[j].X;
				Line_2_Y1 = pos[j].Y;
				Line_2_X2 = pos[j + 1].X;
				Line_2_Y2 = pos[j + 1].Y;
			}
			else
			{
				Line_2_X1 = pos[j].X;
				Line_2_Y1 = pos[j].Y;
				Line_2_X2 = pos[0].X;
				Line_2_Y2 = pos[0].Y;
			}
			myGraf.DrawLine(new Pen(Color.DarkOrange, 3), Line_1_X1, Line_1_Y1, Line_1_X2, Line_1_Y2);
			myGraf.DrawLine(new Pen(Color.DarkOrange, 3), Line_2_X1, Line_2_Y1, Line_2_X2, Line_2_Y2);
			pictureBox1.Refresh();
		}

		void Perimetr()
		{
			double P = 0;
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
				if (dataGridView1.Rows[i].Cells[1].Value != null && dataGridView1.Rows[i].Cells[2].Value != null)
					if (dataGridView1.Rows[i].Cells[1].Value.ToString() != "" && dataGridView1.Rows[i].Cells[2].Value.ToString() != "")
						P += Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value.ToString());
			P += Math.Sqrt(Math.Pow(MyTable[MyTable.GetUpperBound(0), 0] - MyTable[0, 0], 2) + Math.Pow(MyTable[MyTable.GetUpperBound(0), 1] - MyTable[0, 1], 2));
			labelPerimetr2.Text = Math.Round((float)P, 2).ToString();
		}

		public class Pos
		{
			public double X, Y;
			public Pos(double Xcol, double Ycol)
			{
				X = Xcol;
				Y = Ycol;
			}

			public Pos()
			{ }
		}

		bool CreateImage()
		{
			float[,] myTableRev;
			if (changeScale)
			{
				myTableRev = new float[MyTableRevScale.GetLength(0), MyTableRevScale.GetLength(1)];
				for (int i = 0; i < myTableRev.GetLength(0); i++)
					for (int j = 0; j < myTableRev.GetLength(1); j++)
						myTableRev[i, j] = MyTableRevScale[i, j];
			}
			else
			{
				myTableRev = new float[MyTableRev.GetLength(0), MyTableRev.GetLength(1)];
				for (int i = 0; i < MyTableRev.GetLength(0); i++)
					for (int j = 0; j < MyTableRev.GetLength(1); j++)
						myTableRev[i, j] = MyTableRev[i, j];
			}
			//Создаём массив точек путём преобразования
			//математических декартовых координат в экранные пиксельные координаты.
			//И уже в пиксельных координатах строим на экране полученную фигуру
			PosArray = new List<Pos>();
			for (int i = 0; i < myTableRev.GetLength(0); i++)
			{
				newPos = new Pos();
				newPos.X = (float)myTableRev[i, 0];
				newPos.Y = (float)myTableRev[i, 1];
				PosArray.Add(newPos);
			}
			foreach (Pos p in PosArray)
			{
				p.X = Math.Round(Length_Square_pixel * p.X / Length_Square_metre);
				p.Y = Math.Round(Length_Square_pixel * p.Y / Length_Square_metre);
			}
			//Создаём копию для использования при перемещении вершин в методе pictureBox1_MouseMove
			PosArrayNotScale = new List<Pos>();
			for (int i = 0; i < MyTableRev.GetLength(0); i++)
			{
				newPos = new Pos();
				newPos.X = (float)MyTableRev[i, 0];
				newPos.Y = (float)MyTableRev[i, 1];
				PosArrayNotScale.Add(newPos);
			}
			foreach (Pos p in PosArrayNotScale)
			{
				p.X = Math.Round(Length_Square_pixel * p.X / Length_Square_metre);
				p.Y = Math.Round(Length_Square_pixel * p.Y / Length_Square_metre);
			}

			//Дополнительно размещаем по центру экрана отмасштабированную фигуру
			if (changeScale)
			{
				double MinX, MinY, MaxX, MaxY;
				MinX = MaxX = PosArray[0].X;
				MinY = MaxY = PosArray[0].Y;
				foreach (Pos p in PosArray)
				{
					if (p.X < MinX)
						MinX = p.X;
					if (p.X > MaxX)
						MaxX = p.X;
					if (p.Y < MinY)
						MinY = p.Y;
					if (p.Y > MaxY)
						MaxY = p.Y;
				}
				double LengthX, LengthY, PerenX, PerenY;
				LengthX = MaxX - MinX;
				PerenX = (Length_Square_pixel - LengthX) / 2;
				foreach (Pos p in PosArray)
					p.X = p.X - MinX + PerenX;
				LengthY = MaxY - MinY;
				PerenY = (Length_Square_pixel - LengthY) / 2;
				foreach (Pos p in PosArray)
					p.Y = p.Y - MinY + PerenY;
				if (LengthX > Length_Square_pixel || LengthY > Length_Square_pixel)
				{
					timerTurn.Stop();
					timerScale.Stop();
					if (!MoveTop)
						result = MessageBox.Show("В выбранном масштабе фигура не может быть отображена\nЕё размеры превышают размеры рабочей области", "Ошибка пользователя", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					textScale.Text = oldScale.ToString();
					myScale = oldScale;
					if ((changeTurn || MoveTop) && !keyDelete)
					{
						if (MoveTop)
							changeValue = false;
						createImage = true;
						myDataTable.Rows.Clear();
						for (int i = 0; i < myDataTableCopy.Rows.Count; i++)
						{
							DataRow newRow = myDataTable.NewRow();
							myDataTable.Rows.Add(newRow);
							myDataTable.Rows[i][1] = myDataTableCopy.Rows[i][1];
							myDataTable.Rows[i][2] = myDataTableCopy.Rows[i][2];
						}
						textTurn.Text = oldTurn.ToString();
						myTurn = oldTurn;
						createImage = false;
					}
					else if (keyDelete)
						Clear();
					if (MoveTop)
						moveTop = true;
					MoveTop = false;
					return false;
				}
			}
			pos = new Point[PosArray.Count];
			for (int i = 0; i < pos.Length; i++)
				pos[i] = new Point((int)PosArray[i].X, (int)PosArray[i].Y);
			//Создаём копию неотмасштабированных позиций
			//для последующего использования при перемещении вершин в методе pictureBox1_MouseMove
			posNotScale = new Point[PosArrayNotScale.Count];
			for (int i = 0; i < posNotScale.Length; i++)
				posNotScale[i] = new Point((int)PosArrayNotScale[i].X, (int)PosArrayNotScale[i].Y);
			bmp = new Bitmap(Length_Square_pixel, Length_Square_pixel);
			for (int i = 0; i < Length_Square_pixel; i++)
			{
				for (int j = 0; j < Length_Square_pixel; j++)
				{ bmp.SetPixel(i, j, Color.White); }
			}
			pictureBox1.Image = bmp;
			return true;
		}

		void CreatePlan()
		{
			try
			{

				textSquare.Text = Length_Square_metre.ToString();
				if (changeScale)
				{
					CreateMyTableSuccess = CreateMyTable();
					if (CreateMyTableSuccess)
					{
						ChangeScale(myScale);
						CreateImageSuccess = CreateImage();
						if (CreateImageSuccess)
						{
							myDataTableCopy.Rows.Clear();
							for (int i = 0; i < myDataTable.Rows.Count; i++)
							{
								DataRow newRow = myDataTableCopy.NewRow();
								myDataTableCopy.Rows.Add(newRow);
								myDataTableCopy.Rows[i][1] = myDataTable.Rows[i][1];
								myDataTableCopy.Rows[i][2] = myDataTable.Rows[i][2];
							}
							myGraf = Graphics.FromImage(bmp);
							myGraf.FillPolygon(myBrush, pos);
							CreateMarker(myScale);
							DrawGrid();
							DrawSquare(myScale);
							pictureBox1.Refresh();
						}
					}
				}
				else
				{
					CreateMyTableSuccess = CreateMyTable();
					if (CreateMyTableSuccess)
					{
						myDataTableCopy.Rows.Clear();
						for (int i = 0; i < myDataTable.Rows.Count; i++)
						{
							DataRow newRow = myDataTableCopy.NewRow();
							myDataTableCopy.Rows.Add(newRow);
							myDataTableCopy.Rows[i][1] = myDataTable.Rows[i][1];
							myDataTableCopy.Rows[i][2] = myDataTable.Rows[i][2];
						}
						CreateImageSuccess = CreateImage();
						myGraf = Graphics.FromImage(bmp);
						myGraf.FillPolygon(myBrush, pos);
						CreateMarker(myScale);
						DrawGrid();
						DrawSquare(myScale);
						pictureBox1.Refresh();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n\nРЕКОМЕНДУЕТСЯ СОХРАНИТЬ ВСЕ ДАННЫЕ И ПЕРЕЗАГРУЗИТЬ ПРОГРАММУ!", "Ошибка программы", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		class ErrorCell
		{
			public int row;
			public int col;
		}

		void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			result = MessageBox.Show("Входная строка имела неверный формат", "Системная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				ClearLines();
				labelLengthAll.Text = "0";
				labelLengthSegment.Text = "0";
				DataGridView dataGrid = (DataGridView)sender;
				DataGridViewCell dataCell = dataGrid.CurrentCell;
				if (dataCell.Value.ToString() != "")
				{
					DataRow newRow = myDataTable.NewRow();
					float cellVal = Convert.ToSingle(dataCell.Value.ToString());
					if (e.ColumnIndex == 1)
					{
						if ((cellVal >= 0 && cellVal < 360) || rowInsWithMouse || MoveTop)
							try
							{
								newRow["Азимут"] = cellVal;
								dataCell.Style.BackColor = cellBackColor;
								dataCell.Tag = null;
								foreach (ErrorCell ec in ErrorCellArray)
									if (dataCell.ColumnIndex == ec.col && dataCell.RowIndex == ec.row)
										ErrorCellArray.Remove(ec);
							}
							catch (Exception)
							{ }
						else if (!KeyBack && !rowDel)
						{
							result = MessageBox.Show("Вы неверно ввели Азимут", "Ошибка пользователя", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							if (dataCell.Tag == null)
							{
								ErrorCell errorCell = new ErrorCell();
								errorCell.row = dataCell.RowIndex;
								errorCell.col = dataCell.ColumnIndex;
								ErrorCellArray.Add(errorCell);
							}
							dataGrid[e.ColumnIndex, e.RowIndex].Tag = "red";
							dataGrid[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Red;
						}
					}
					else
					{
						if (cellVal > 0 || rowInsWithMouse || MoveTop)
							try
							{
								newRow["Длина"] = cellVal;
								dataCell.Style.BackColor = cellBackColor;
								dataCell.Tag = null;
								foreach (ErrorCell ec in ErrorCellArray)
									if (dataCell.ColumnIndex == ec.col && dataCell.RowIndex == ec.row)
										ErrorCellArray.Remove(ec);
							}
							catch (Exception)
							{ }
						else if (!KeyBack && !rowDel)
						{
							result = MessageBox.Show("Вы неверно ввели Длину", "Ошибка пользователя", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							if (dataCell.Tag == null)
							{
								ErrorCell errorCell = new ErrorCell();
								errorCell.row = dataCell.RowIndex;
								errorCell.col = dataCell.ColumnIndex;
								ErrorCellArray.Add(errorCell);
							}
							dataGrid[e.ColumnIndex, e.RowIndex].Tag = "red";
							dataGrid[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Red;
						}
					}
				}
				KeyBack = false;
				changeValue = true;
				cellValue = true;
				res = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n\nРЕКОМЕНДУЕТСЯ СОХРАНИТЬ ВСЕ ДАННЫЕ И ПЕРЕЗАГРУЗИТЬ ПРОГРАММУ!", "Ошибка программы", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void dataGridView1_KeyUp(object sender, KeyEventArgs e)
		{
			if (result == DialogResult.OK)
			{
				result = DialogResult.Cancel;
				res = true;
			}
			else if (e.KeyCode == Keys.Enter && result != DialogResult.OK && (!textSquareKeyPressBOOL || changeValue))
			{
				dataGridView1KeyUp();
				res = false;
			}
			textSquareKeyPressBOOL = false;
		}

		void dataGridView1KeyUp()
		{
			try
			{
				MoveTop = false;
				moveTop = false;
				ClearLines();
				labelLengthAll.Text = "0";
				labelLengthSegment.Text = "0";
				int rowCount = dataGridView1.Rows.Count;
				if (dataGridView1.Rows.Count != 1)
					if (dataGridView1.Rows[rowCount - 2].Cells[1].Value.ToString() == "" && dataGridView1.Rows[rowCount - 2].Cells[2].Value.ToString() == "")
						dataGridView1.Rows.Remove(dataGridView1.Rows[rowCount - 2]);

				for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
				{
					if (dataGridView1[1, i].Value.ToString() == "" && dataGridView1[2, i].Value.ToString() == "")
					{ }
					else
					{
						if (dataGridView1[1, i].Value.ToString() == "")
						{
							if (dataGridView1[1, i].Tag == null)
							{
								ErrorCell errorCell = new ErrorCell();
								errorCell.row = i;
								errorCell.col = 1;
								ErrorCellArray.Add(errorCell);
							}
							dataGridView1.Rows[i].Cells[1].Style.BackColor = Color.Red;
							dataGridView1.Rows[i].Cells[1].Tag = "red";
						}
						if (dataGridView1[2, i].Value.ToString() == "")
						{
							if (dataGridView1[2, i].Tag == null)
							{
								ErrorCell errorCell = new ErrorCell();
								errorCell.row = i;
								errorCell.col = 2;
								ErrorCellArray.Add(errorCell);
							}
							dataGridView1.Rows[i].Cells[2].Style.BackColor = Color.Red;
							dataGridView1.Rows[i].Cells[2].Tag = "red";
						}
					}
				}
				if (ErrorCellArray.Count == 0 && myDataTable.Rows.Count > 1)
				{
					try
					{
						for (int i = 0; i < myDataTable.Rows.Count; i++)
							if (myDataTable.Rows[i][1].ToString() == "" && myDataTable.Rows[i][2].ToString() == "")
								myDataTable.Rows[i].Delete();
						changeScale = false;
						myScale = 100;
						textScale.Text = "100";
						textScale.Enabled = true;
						butScaleMin.Enabled = true;
						butScaleMax.Enabled = true;
						chTurn = false;
						changeTurn = false;
						myTurn = 0;
						textTurn.Text = "0";
						textTurn.Enabled = true;
						buttonLeft.Enabled = true;
						buttonRight.Enabled = true;
						сохранитьФайлToolStripMenuItem2.Enabled = true;
						CreatePlan();
						if (CreateMyTableSuccess || changeTurn || MoveTop)
						{
							Square();
							Perimetr();
						}
						else
						{
							labelSquare2.Text = "0";
							labelSquare2.ForeColor = Color.Blue;
							if (rowPeresech_1 != -1 && rowPeresech_2 != -1)
							{
								dataGridView1.Rows[rowPeresech_1].DefaultCellStyle.BackColor = cellBackColor;
								dataGridView1.Rows[rowPeresech_2].DefaultCellStyle.BackColor = cellBackColor;
								rowPeresech_1 = -1; rowPeresech_2 = -1;
							}
							labelPerimetr2.Text = "0";
						}
						DrawPanel();
					}
					catch (Exception ex)
					{
						result = MessageBox.Show(ex.Message, "Системная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else if (dataGridView1.Rows.Count > 2 || (dataGridView1.Rows.Count == 2 && ((dataGridView1.Rows[0].Cells[1].Value.ToString() != "" && dataGridView1.Rows[0].Cells[2].Value.ToString() == "") || (dataGridView1.Rows[0].Cells[1].Value.ToString() == "" && dataGridView1.Rows[0].Cells[2].Value.ToString() != ""))))
				{
					result = MessageBox.Show("Вы неверно ввели исходные данных", "Ошибка пользователя", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					Clear();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n\nРЕКОМЕНДУЕТСЯ СОХРАНИТЬ ВСЕ ДАННЫЕ И ПЕРЕЗАГРУЗИТЬ ПРОГРАММУ!", "Ошибка программы", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void dataGridView1_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Back)
				{
					MoveTop = false;
					moveTop = false;
					ClearLines();
					labelLengthAll.Text = "0";
					labelLengthSegment.Text = "0";
					KeyBack = true;
					try
					{
						if (dataGridView1.CurrentCell.ColumnIndex == 1)
							dataGridView1.CurrentCell.Value = 360;
						else
							dataGridView1.CurrentCell.Value = 0;
						if (dataGridView1.CurrentCell.Tag == null)
						{
							ErrorCell errorCell = new ErrorCell();
							errorCell.row = dataGridView1.CurrentCell.RowIndex;
							errorCell.col = dataGridView1.CurrentCell.ColumnIndex;
							ErrorCellArray.Add(errorCell);
						}
						dataGridView1.CurrentCell.Style.BackColor = Color.Red;
						dataGridView1.CurrentCell.Tag = "red";
						Clear();
					}
					catch (Exception ex)
					{
						result = MessageBox.Show(ex.Message, "Системная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}

				if (e.KeyCode == Keys.Delete)
				{
					keyDelete = true;
					MoveTop = false;
					moveTop = false;
					ClearLines();
					labelLengthAll.Text = "0";
					labelLengthSegment.Text = "0";
					try
					{
						for (int i = 0; i < myDataTable.Rows.Count; i++)
							if (myDataTable.Rows[i][1].ToString() == "" && myDataTable.Rows[i][2].ToString() == "")
								myDataTable.Rows[i].Delete();

						int j = 0;
						for (int i = 0; i < dataGridView1.Rows.Count; i++)
							if (dataGridView1.Rows[i].Selected || dataGridView1[1, i].Selected || dataGridView1[2, i].Selected)
							{ j++; delRow = i; }
						if (j > 1)
						{
							result = MessageBox.Show("Выберите нужную строку для удаления", "Ошибка пользователя", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
						else if (j == 1)
						{
							for (int i = 1; i <= 2; i++)
								foreach (ErrorCell errCell in ErrorCellArray)
									if (errCell.row == delRow)
									{
										ErrorCellArray.Remove(errCell);
										break;
									}
							foreach (ErrorCell errCell in ErrorCellArray)
								if (errCell.row > delRow)
									errCell.row--;
							if (delRow != dataGridView1.Rows.Count - 1)
							{
								if (rowPeresech_1 != -1 && rowPeresech_2 != -1)
								{
									dataGridView1.Rows[rowPeresech_1].DefaultCellStyle.BackColor = cellBackColor;
									dataGridView1.Rows[rowPeresech_2].DefaultCellStyle.BackColor = cellBackColor;
									rowPeresech_1 = -1; rowPeresech_2 = -1;
								}
								rowDel = true;
								dataGridView1.Rows.Remove(dataGridView1.Rows[delRow]);
								myDataTable.AcceptChanges();
								rowDel = false;
							}
							foreach (ErrorCell errCell in ErrorCellArray)
							{
								dataGridView1.Rows[errCell.row].Cells[errCell.col].Style.BackColor = Color.Red;
								dataGridView1.Rows[errCell.row].Cells[errCell.col].Tag = "red";
							}
							if (myDataTable.Rows.Count > 1 && ErrorCellArray.Count == 0 && labelSquare2.Text != "0")
							{
								buttonLeft.Enabled = true;
								buttonRight.Enabled = true;
								textTurn.Enabled = true;
								butScaleMin.Enabled = true;
								butScaleMax.Enabled = true;
								textScale.Enabled = true;
								сохранитьФайлToolStripMenuItem2.Enabled = true;
								CreatePlan();
								if ((CreateMyTableSuccess || changeTurn || MoveTop))
								{
									Square();
									Perimetr();
								}
							}
							DrawPanel();
						}
						for (int i = 0; i < myDataTable.Rows.Count; i++)
							if (myDataTable.Rows[i][1].ToString() == "" && myDataTable.Rows[i][2].ToString() == "")
								myDataTable.Rows[i].Delete();
						if (dataGridView1.Rows.Count <= 2 || (dataGridView1.Rows.Count == 3 && dataGridView1.Rows[1].Cells[1].Value.ToString() == "" && dataGridView1.Rows[1].Cells[1].Value.ToString() == ""))
							Clear();
						dataGridView1.Refresh();
						if (dataGridView1.Rows.Count == 1)
						{
							dataGridView1.Rows[0].Cells[1].Selected = true;
							dataGridView1.Focus();
						}
					}
					catch (Exception ex)
					{
						result = MessageBox.Show(ex.Message, "Системная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					keyDelete = false;
				}

				if (e.KeyCode == Keys.Insert)
				{
					keyInsert = true;
					MoveTop = false;
					moveTop = false;
					ClearLines();
					labelLengthAll.Text = "0";
					labelLengthSegment.Text = "0";
					try
					{
						if (myDataTable.Rows.Count != 0)
						{
							for (int i = 0; i < myDataTable.Rows.Count; i++)
								if (myDataTable.Rows[i][1].ToString() == "" && myDataTable.Rows[i][2].ToString() == "")
									myDataTable.Rows[i].Delete();
						}

						int iNum = 0;
						if (myDataTable.Rows.Count > 0)
						{
							for (int i = 0; i < dataGridView1.Rows.Count; i++)
								if (dataGridView1.Rows[i].Selected || dataGridView1[1, i].Selected || dataGridView1[2, i].Selected)
									iNum = i;
							if (labelSquare2.Text != "0" && ErrorCellArray.Count == 0)
							{
								if (rowPeresech_1 != -1 && rowPeresech_2 != -1)
								{
									dataGridView1.Rows[rowPeresech_1].DefaultCellStyle.BackColor = cellBackColor;
									dataGridView1.Rows[rowPeresech_2].DefaultCellStyle.BackColor = cellBackColor;
									rowPeresech_1 = -1; rowPeresech_2 = -1;
								}
								DataRow newRow = myDataTable.NewRow();
								rowIns = true;
								myDataTable.Rows.InsertAt(newRow, iNum);
								myDataTable.Rows[iNum][1] = 360;
								myDataTable.Rows[iNum][2] = 0;
								dataGridView1.Refresh();
								dataGridView1.Rows[iNum].Cells[1].Style.BackColor = Color.Red;
								dataGridView1.Rows[iNum].Cells[1].Tag = "red";
								ErrorCell errorCell = new ErrorCell();
								errorCell.row = iNum;
								errorCell.col = 1;
								ErrorCellArray.Add(errorCell);
								dataGridView1.Rows[iNum].Cells[2].Style.BackColor = Color.Red;
								dataGridView1.Rows[iNum].Cells[2].Tag = "red";
								errorCell = new ErrorCell();
								errorCell.row = iNum;
								errorCell.col = 2;
								ErrorCellArray.Add(errorCell);
								Clear();
							}
							else
							{
								result = MessageBox.Show("Выполните вначале построение фигуры", "Ошибка пользователя", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								foreach (ErrorCell errCell in ErrorCellArray)
									dataGridView1.Rows[errCell.row].Cells[errCell.col].Style.BackColor = Color.Red;
							}
						}
					}
					catch (Exception ex)
					{
						result = MessageBox.Show(ex.Message, "Системная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					keyInsert = false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n\nРЕКОМЕНДУЕТСЯ СОХРАНИТЬ ВСЕ ДАННЫЕ И ПЕРЕЗАГРУЗИТЬ ПРОГРАММУ!", "Ошибка программы", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
		{
			if (createImage || tableClear)
			{
				cellValue = false;
				return;
			}
			if (labelSquare2.Text != "0" && !textSquareKeyPressBOOL && !keyInsert)
			{
				if (moveTop)
				{
					MoveTop = false;
					moveTop = false;
					chTurn = false;
					if (!cellValue)
						changeValue = false;
				}
				ClearLines();
				CreatePlan();
				Square();
				Perimetr();
			}
			cellValue = false;
		}

		class OldCell
		{
			int row = 0; int col = 1;
			public int Row
			{
				get
				{ return row; }
				set
				{ row = value; }
			}
			public int Col
			{
				get
				{ return col; }
				set
				{ col = value; }
			}
		}
		OldCell oldCell = new OldCell();

		void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
		{
			oldCell.Row = e.RowIndex;
			oldCell.Col = e.ColumnIndex;
		}

		void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (chTurn)
			{
				chTurn = false;
				changeValue = false;
			}
			else if ((oldCell.Row != e.RowIndex || oldCell.Col != e.ColumnIndex) && changeValue && !textSquareKeyPressBOOL && !res && !moveTop && !keyDelete && !keyInsert)
			{
				res = false;
				chTurn = false;
				changeValue = false;
				Clear();
			}
		}

		private void textSquare_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == (char)Keys.Enter)
					textSquareKeyPress();
			}
			catch (Exception ex)
			{
				result = MessageBox.Show(ex.Message, "Системная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void textSquareKeyPress()
		{
			MoveTop = false;
			moveTop = false;
			textSquareKeyPressBOOL = true;
			ClearLines();
			labelLengthAll.Text = "0";
			labelLengthSegment.Text = "0";
			if (textSquare.Text != "" && Convert.ToSingle(textSquare.Text) > 0)
			{
				try
				{
					OldLength = Length_Square_metre;
					Length_Square_metre = Convert.ToSingle(textSquare.Text);
					textSquare.Text = Length_Square_metre.ToString();
					buttonClear.Enabled = true;
					dataGridView1.Enabled = true;
					dataGridView1.Rows[0].Cells[1].Selected = true;
					dataGridView1.Focus();
					if (dataGridView1.Rows.Count > 2 && ErrorCellArray.Count == 0)
					{
						CreatePlan();
						if (CreateMyTableSuccess && CreateImageSuccess)
						{
							textTurn.Enabled = true;
							buttonLeft.Enabled = true;
							buttonRight.Enabled = true;
							textScale.Enabled = true;
							butScaleMin.Enabled = true;
							butScaleMax.Enabled = true;
							сохранитьФайлToolStripMenuItem2.Enabled = true;
							if (CreateMyTableSuccess || changeTurn || MoveTop)
							{
								Square();
								Perimetr();
							}
							else
							{
								labelSquare2.Text = "0";
								labelSquare2.ForeColor = Color.Blue;
								if (rowPeresech_1 != -1 && rowPeresech_2 != -1)
								{
									dataGridView1.Rows[rowPeresech_1].DefaultCellStyle.BackColor = cellBackColor;
									dataGridView1.Rows[rowPeresech_2].DefaultCellStyle.BackColor = cellBackColor;
									rowPeresech_1 = -1; rowPeresech_2 = -1;
								}
								labelPerimetr2.Text = "0";
							}
						}
						else
						{
							textSquare.Text = OldLength.ToString();
							Length_Square_metre = Convert.ToSingle(textSquare.Text);
							textSquare.Text = Length_Square_metre.ToString();
							CreatePlan();
							Square();
							Perimetr();
						}
					}
					else
					{
						labelSquare2.Text = "0";
						labelSquare2.ForeColor = Color.Blue;
						if (rowPeresech_1 != -1 && rowPeresech_2 != -1)
						{
							dataGridView1.Rows[rowPeresech_1].DefaultCellStyle.BackColor = cellBackColor;
							dataGridView1.Rows[rowPeresech_2].DefaultCellStyle.BackColor = cellBackColor;
							rowPeresech_1 = -1; rowPeresech_2 = -1;
						}
						labelPerimetr2.Text = "0";
					}
					drawPanel = true;
					DrawPanel();
				}
				catch (Exception ex)
				{
					result = MessageBox.Show(ex.Message, "Системная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
				result = MessageBox.Show("Вы не ввели необходимых данных", "Ошибка пользователя", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		private void buttonClear_Click(object sender, EventArgs e)
		{
			buttonClearClick();
		}

		void buttonClearClick()
		{
			try
			{
				Clear();
				RLF = false; byte RL = 0;
				RAF = false; byte RA = 0;
				this.Text = "Файл \"Без имени\"";
				textSquare.Text = "";
				textSquare.Enabled = true;
				textSquare.Focus();
				buttonClear.Enabled = false;
				tableClear = true;
				myDataTable.Clear();
				tableClear = false;
				dataGridView1.Enabled = false;
				ErrorCellArray.Clear();
				drawPanel = false;
				Graphics p2 = Graphics.FromHwnd(panel2.Handle);
				p2.Clear(formBackColor);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n\nРЕКОМЕНДУЕТСЯ СОХРАНИТЬ ВСЕ ДАННЫЕ И ПЕРЕЗАГРУЗИТЬ ПРОГРАММУ!", "Ошибка программы", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void Clear()
		{
			res = false;
			MoveTop = false;
			moveTop = false;
			ClearLines();
			labelLengthAll.Text = "0";
			labelLengthSegment.Text = "0";
			labelSquare2.Text = "0";
			labelSquare2.ForeColor = Color.Blue;
			if (rowPeresech_1 != -1 && rowPeresech_2 != -1)
			{
				dataGridView1.Rows[rowPeresech_1].DefaultCellStyle.BackColor = cellBackColor;
				dataGridView1.Rows[rowPeresech_2].DefaultCellStyle.BackColor = cellBackColor;
				rowPeresech_1 = -1; rowPeresech_2 = -1;
			}
			labelPerimetr2.Text = "0";
			buttonLeft.Enabled = false;
			buttonRight.Enabled = false;
			textTurn.Text = "0";
			textTurn.Enabled = false;
			myTurn = 0;
			chTurn = false;
			changeTurn = false;
			butScaleMin.Enabled = false;
			butScaleMax.Enabled = false;
			textScale.Text = "100";
			textScale.Enabled = false;
			myScale = 100;
			changeScale = false;
			сохранитьФайлToolStripMenuItem2.Enabled = false;
			if (!textSquareKeyPressBOOL)
				pictureBox1.Image = null;
		}

		void textTurn_KeyPress(object sender, KeyPressEventArgs e)
		{
			MoveTop = false;
			moveTop = false;
			ClearLines();
			labelLengthAll.Text = "0";
			labelLengthSegment.Text = "0";
			try
			{
				if (e.KeyChar == (char)Keys.Enter)
				{
					if (textTurn.Text != "" && Convert.ToSingle(textTurn.Text) > -360 && Convert.ToSingle(textTurn.Text) < 360)
					{
						chTurn = true;
						changeTurn = true;
						oldTurn = myTurn;
						myTurn = Convert.ToSingle(textTurn.Text);
						ChangeAzimut(Convert.ToSingle(myTurn - oldTurn));
						oldTurn = myTurn;
					}
					else
						result = MessageBox.Show("Вы неверно ввели угол поворота", "Ошибка пользователя", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (Exception ex)
			{
				result = MessageBox.Show(ex.Message, "Системная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void buttonLeft_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			MoveTop = false;
			moveTop = false;
			ClearLines();
			labelLengthAll.Text = "0";
			labelLengthSegment.Text = "0";
			if (e.KeyCode.ToString() == Keys.Enter.ToString() || e.KeyCode.ToString() == Keys.Space.ToString())
			{
				chTurn = true;
				changeTurn = true;
				timerTurn.Start();
				butTimeR = false;
			}
		}

		void buttonRight_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			MoveTop = false;
			moveTop = false;
			ClearLines();
			labelLengthAll.Text = "0";
			labelLengthSegment.Text = "0";
			if (e.KeyCode.ToString() == Keys.Enter.ToString() || e.KeyCode.ToString() == Keys.Space.ToString())
			{
				chTurn = true;
				changeTurn = true;
				timerTurn.Start();
				butTimeR = true;
			}
		}

		void buttonLeft_KeyUp(object sender, KeyEventArgs e)
		{
			timerTurn.Stop();
		}

		void buttonRight_KeyUp(object sender, KeyEventArgs e)
		{
			timerTurn.Stop();
		}

		void buttonLeft_MouseDown(object sender, MouseEventArgs e)
		{
			MoveTop = false;
			moveTop = false;
			ClearLines();
			labelLengthAll.Text = "0";
			labelLengthSegment.Text = "0";
			chTurn = true;
			changeTurn = true;
			timerTurn.Start();
			butTimeR = false;
		}

		void buttonRight_MouseDown(object sender, MouseEventArgs e)
		{
			MoveTop = false;
			moveTop = false;
			ClearLines();
			labelLengthAll.Text = "0";
			labelLengthSegment.Text = "0";
			chTurn = true;
			changeTurn = true;
			timerTurn.Start();
			butTimeR = true;
		}

		void buttonLeft_MouseUp(object sender, MouseEventArgs e)
		{
			timerTurn.Stop();
		}

		void buttonRight_MouseUp(object sender, MouseEventArgs e)
		{
			timerTurn.Stop();
		}

		void timer_Tick(object sender, EventArgs e)
		{
			oldTurn = myTurn;
			if (butTimeR)
			{
				myTurn += 3;
				if (myTurn == 360)
				{
					myTurn = 0;
					ChangeAzimut(-357);
					oldTurn = myTurn;
				}
				else
				{
					ChangeAzimut(3);
					oldTurn = myTurn;
				}
				textTurn.Text = myTurn.ToString();
			}
			else
			{
				myTurn -= 3;
				if (myTurn == -360)
				{
					myTurn = 0;
					ChangeAzimut(357);
					oldTurn = myTurn;
				}
				else
				{
					ChangeAzimut(-3);
					oldTurn = myTurn;
				}
				textTurn.Text = myTurn.ToString();
			}
		}

		void ChangeAzimut(float incr)
		{
			try
			{
				for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
					if (dataGridView1.Rows[i].Cells[1].Value.ToString() != "" && dataGridView1.Rows[i].Cells[2].Value.ToString() != "")
					{
						if (Convert.ToSingle(dataGridView1.Rows[i].Cells[1].Value) + incr >= 0 && Convert.ToSingle(dataGridView1.Rows[i].Cells[1].Value) + incr < 360)
							dataGridView1.Rows[i].Cells[1].Value = Math.Round(Convert.ToSingle(dataGridView1.Rows[i].Cells[1].Value) + incr, 2);
						else if (Convert.ToSingle(dataGridView1.Rows[i].Cells[1].Value) + incr == 360)
							dataGridView1.Rows[i].Cells[1].Value = 0;
						else if (Convert.ToSingle(dataGridView1.Rows[i].Cells[1].Value) + incr > 360)
							dataGridView1.Rows[i].Cells[1].Value = Math.Round(Convert.ToSingle(dataGridView1.Rows[i].Cells[1].Value) + incr - 360, 2);
						else
							dataGridView1.Rows[i].Cells[1].Value = Math.Round(Convert.ToSingle(dataGridView1.Rows[i].Cells[1].Value) + incr + 360, 2);
					}
				CreatePlan();
				DrawPanel();
				if (CreateMyTableSuccess || changeTurn || MoveTop)
				{
					Square();
					Perimetr();
				}
				else
				{
					labelSquare2.Text = "0";
					labelSquare2.ForeColor = Color.Blue;
					if (rowPeresech_1 != -1 && rowPeresech_2 != -1)
					{
						dataGridView1.Rows[rowPeresech_1].DefaultCellStyle.BackColor = cellBackColor;
						dataGridView1.Rows[rowPeresech_2].DefaultCellStyle.BackColor = cellBackColor;
						rowPeresech_1 = -1; rowPeresech_2 = -1;
					}
					labelPerimetr2.Text = "0";
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n\nРЕКОМЕНДУЕТСЯ СОХРАНИТЬ ВСЕ ДАННЫЕ И ПЕРЕЗАГРУЗИТЬ ПРОГРАММУ!", "Ошибка программы", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void textScale_KeyPress(object sender, KeyPressEventArgs e)
		{
			//MoveTop = false; // Наверное ошибочно
			//moveTop = false; // Наверное ошибочно
			ClearLines();
			labelLengthAll.Text = "0";
			labelLengthSegment.Text = "0";
			try
			{
				if (e.KeyChar == (char)Keys.Enter)
				{
					if (textScale.Text != "" && Convert.ToSingle(textScale.Text) >= 10 && Convert.ToSingle(textScale.Text) <= 1000)
					{
						changeScale = true;
						oldScale = myScale;
						myScale = Convert.ToSingle(textScale.Text);
						CreatePlan();
						Square();
						Perimetr();
						oldScale = myScale;
						DrawPanel();
					}
					else
						result = MessageBox.Show("Вы неверно ввели масштаб", "Ошибка пользователя", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (Exception ex)
			{
				result = MessageBox.Show(ex.Message, "Системная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void butScaleMin_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			//MoveTop = false; // Наверное ошибочно
			//moveTop = false; // Наверное ошибочно	
			ClearLines();
			labelLengthAll.Text = "0";
			labelLengthSegment.Text = "0";
			if (e.KeyCode.ToString() == Keys.Enter.ToString() || e.KeyCode.ToString() == Keys.Space.ToString())
			{
				changeScale = true;
				timerScale.Start();
				butScaleR = false;
			}
		}

		void butScaleMax_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			//MoveTop = false; // Наверное ошибочно
			//moveTop = false; // Наверное ошибочно	
			ClearLines();
			labelLengthAll.Text = "0";
			labelLengthSegment.Text = "0";
			if (e.KeyCode.ToString() == Keys.Enter.ToString() || e.KeyCode.ToString() == Keys.Space.ToString())
			{
				changeScale = true;
				timerScale.Start();
				butScaleR = true;
			}
		}

		void butScaleMin_KeyUp(object sender, KeyEventArgs e)
		{
			timerScale.Stop();
		}

		void butScaleMax_KeyUp(object sender, KeyEventArgs e)
		{
			timerScale.Stop();
		}

		void butScaleMin_MouseDown(object sender, MouseEventArgs e)
		{
			//MoveTop = false; // Наверное ошибочно
			//moveTop = false; // Наверное ошибочно
			ClearLines();
			labelLengthAll.Text = "0";
			labelLengthSegment.Text = "0";
			changeScale = true;
			timerScale.Start();
			butScaleR = false;
		}

		void butScaleMax_MouseDown(object sender, MouseEventArgs e)
		{
			//MoveTop = false; // Наверное ошибочно
			//moveTop = false; // Наверное ошибочно
			ClearLines();
			labelLengthAll.Text = "0";
			labelLengthSegment.Text = "0";
			changeScale = true;
			timerScale.Start();
			butScaleR = true;
		}

		void butScaleMin_MouseUp(object sender, MouseEventArgs e)
		{
			timerScale.Stop();
		}

		void butScaleMax_MouseUp(object sender, MouseEventArgs e)
		{
			timerScale.Stop();
		}

		void timerScale_Tick(object sender, EventArgs e)
		{
			oldScale = myScale;
			if (butScaleR)
			{
				if (myScale < 1000)
				{
					myScale += 5;
					CreatePlan();
					Square();
					Perimetr();
					oldScale = myScale;
					DrawPanel();
					textScale.Text = myScale.ToString();
				}
				else
				{
					timerScale.Stop();
					result = MessageBox.Show("Дальнейшее изменение масштаба невозможно", "Ошибка пользователя", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}
			else
			{
				if (myScale > 10)
				{
					myScale -= 5;
					CreatePlan();
					Square();
					Perimetr();
					oldScale = myScale;
					DrawPanel();
					textScale.Text = myScale.ToString();
				}
				else
				{
					timerScale.Stop();
					result = MessageBox.Show("Дальнейшее изменение масштаба невозможно", "Ошибка пользователя", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}
		}

		//Реализуем построение фигуры в масштабе
		void ChangeScale(float scale)
		{
			try
			{
				//Создаём масштабированную таблицу
				MyTableScale = new float[MyTableCopy.GetLength(0), MyTableCopy.GetLength(1)];
				for (int i = 0; i < MyTableScale.GetLength(0); i++)
					for (int j = 0; j < MyTableScale.GetLength(1); j++)
						MyTableScale[i, j] = MyTableCopy[i, j] * scale / 100;
				//Масштабируем размер внешнего квадрата
				Length_Square_metreScale = Length_Square_metre * scale / 100;

				//Находим минимальные и максимальные координаты по осям X и Y
				float MinX, MinY, MaxX, MaxY;
				MinX = MinY = MaxX = MaxY = 0;
				for (int i = 0; i < MyTableScale.GetLength(0); i++)
				{
					if (MyTableScale[i, 0] < MinX)
						MinX = MyTableScale[i, 0];
					if (MyTableScale[i, 0] > MaxX)
						MaxX = MyTableScale[i, 0];
					if (MyTableScale[i, 1] < MinY)
						MinY = MyTableScale[i, 1];
					if (MyTable[i, 1] > MaxY)
						MaxY = MyTableScale[i, 1];
				}
				//Располагаем отмасштабированную фигуру по центру первой декартовой полуплоскости.
				float LengthX, LengthY, PerenX, PerenY;
				if (MinX < 0)
				{
					LengthX = Math.Abs(MinX) + MaxX;
					PerenX = (Length_Square_metreScale - LengthX) / 2;
					for (int i = 0; i < MyTableScale.GetLength(0); i++)
						MyTableScale[i, 0] = MyTableScale[i, 0] + Math.Abs(MinX) + PerenX;
				}
				else
				{
					LengthX = MaxX;
					PerenX = (Length_Square_metreScale - LengthX) / 2;
					for (int i = 0; i < MyTableScale.GetLength(0); i++)
						MyTableScale[i, 0] = MyTableScale[i, 0] + PerenX;
				}
				if (MinY < 0)
				{
					LengthY = Math.Abs(MinY) + MaxY;
					PerenY = (Length_Square_metreScale - LengthY) / 2;
					for (int i = 0; i < MyTableScale.GetLength(0); i++)
						MyTableScale[i, 1] = MyTableScale[i, 1] + Math.Abs(MinY) + PerenY;
				}
				else
				{
					LengthY = MaxY;
					PerenY = (Length_Square_metreScale - LengthY) / 2;
					for (int i = 0; i < MyTableScale.GetLength(0); i++)
						MyTableScale[i, 1] = MyTableScale[i, 1] + PerenY;
				}
				MyTableRevScale = new float[myDataTable.Rows.Count + 1, myDataTable.Columns.Count - 1];
				for (int i = 0; i < MyTableScale.GetLength(0); i++)
				{
					MyTableRevScale[i, 0] = MyTableScale[i, 0];
					MyTableRevScale[i, 1] = Length_Square_metreScale - MyTableScale[i, 1];
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n\nРЕКОМЕНДУЕТСЯ СОХРАНИТЬ ВСЕ ДАННЫЕ И ПЕРЕЗАГРУЗИТЬ ПРОГРАММУ!", "Ошибка программы", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void CreateMarker(float myScale)
		{
			try
			{
				int rowNum;
				if (rowDel)
					rowNum = delRow;
				else if (rowIns)
				{
					rowIns = false;
					return;
				}
				else if (tableClear)
					return;
				else if (MoveTop || moveTop || rowInsWithMouse)
					rowNum = RowForMoveTop;
				else
					rowNum = dataGridView1.CurrentCell.RowIndex;
				int posX = pos[rowNum].X;
				int posY = pos[rowNum].Y;
				int posX2, posY2;
				if (rowNum != pos.GetLength(0) - 1)
				{
					posX2 = pos[rowNum + 1].X;
					posY2 = pos[rowNum + 1].Y;
				}
				else
				{
					posX2 = pos[0].X;
					posY2 = pos[0].Y;
				}
				myGraf.DrawLine(new Pen(Color.Magenta, 3), posX, posY, posX2, posY2);
				myGraf.DrawEllipse(new Pen(Color.Red, 2), posX - 4, posY - 4, 8, 8);
			}
			catch { }
		}

		void Form1_Paint(object sender, PaintEventArgs e)
		{
			if (drawPanel)
				DrawPanel();
		}

		void DrawPanel()
		{
			Pen penPan = new Pen(Color.DarkRed, 1);
			Font fontPan = new Font("Arial", 12, FontStyle.Bold);
			Graphics p2 = Graphics.FromHwnd(panel2.Handle);
			p2.Clear(formBackColor);
			p2.DrawLine(penPan, 15, 0, 15, 500);
			p2.DrawLine(penPan, 0, 0, 15, 0);
			p2.DrawLine(penPan, 10, 25, 15, 25);
			p2.DrawLine(penPan, 5, 50, 15, 50);
			p2.DrawLine(penPan, 10, 75, 15, 75);
			p2.DrawLine(penPan, 0, 100, 15, 100);
			p2.DrawLine(penPan, 10, 125, 15, 125);
			p2.DrawLine(penPan, 5, 150, 15, 150);
			p2.DrawLine(penPan, 10, 175, 15, 175);
			p2.DrawLine(penPan, 0, 200, 15, 200);
			p2.DrawLine(penPan, 10, 225, 15, 225);
			p2.DrawLine(penPan, 5, 250, 15, 250);
			p2.DrawLine(penPan, 10, 275, 15, 275);
			p2.DrawLine(penPan, 0, 300, 15, 300);
			p2.DrawLine(penPan, 10, 325, 15, 325);
			p2.DrawLine(penPan, 5, 350, 15, 350);
			p2.DrawLine(penPan, 10, 375, 15, 375);
			p2.DrawLine(penPan, 0, 400, 15, 400);
			p2.DrawLine(penPan, 10, 425, 15, 425);
			p2.DrawLine(penPan, 5, 450, 15, 450);
			p2.DrawLine(penPan, 10, 475, 15, 475);
			p2.DrawLine(penPan, 0, 500, 15, 500);
			if (changeScale)
				p2.DrawString(Math.Round((Length_Square_metre * 100 / myScale), 2).ToString() + ", м", fontPan, Brushes.DarkRed, new RectangleF(20, 220, 20, 200), new StringFormat(StringFormatFlags.DirectionVertical));
			else
				p2.DrawString(Math.Round(Length_Square_metre, 2).ToString() + ", м", fontPan, Brushes.DarkRed, new RectangleF(20, 220, 20, 200), new StringFormat(StringFormatFlags.DirectionVertical));
		}

		void DrawGrid()
		{
			Pen penGridThick = new Pen(Color.Thistle, 2F);
			penGridThick.DashStyle = DashStyle.DashDotDot;
			Pen penGridThin = new Pen(Color.Thistle, 1F);
			penGridThin.DashStyle = DashStyle.DashDotDot;

			myGraf.DrawLine(penGridThin, 25, 0, 25, 500);
			myGraf.DrawLine(penGridThin, 50, 0, 50, 500);
			myGraf.DrawLine(penGridThin, 75, 0, 75, 500);
			myGraf.DrawLine(penGridThick, 100, 0, 100, 500);
			myGraf.DrawLine(penGridThin, 125, 0, 125, 500);
			myGraf.DrawLine(penGridThin, 150, 0, 150, 500);
			myGraf.DrawLine(penGridThin, 175, 0, 175, 500);
			myGraf.DrawLine(penGridThick, 200, 0, 200, 500);
			myGraf.DrawLine(penGridThin, 225, 0, 225, 500);
			myGraf.DrawLine(penGridThin, 250, 0, 250, 500);
			myGraf.DrawLine(penGridThin, 275, 0, 275, 500);
			myGraf.DrawLine(penGridThick, 300, 0, 300, 500);
			myGraf.DrawLine(penGridThin, 325, 0, 325, 500);
			myGraf.DrawLine(penGridThin, 350, 0, 350, 500);
			myGraf.DrawLine(penGridThin, 375, 0, 375, 500);
			myGraf.DrawLine(penGridThick, 400, 0, 400, 500);
			myGraf.DrawLine(penGridThin, 425, 0, 425, 500);
			myGraf.DrawLine(penGridThin, 450, 0, 450, 500);
			myGraf.DrawLine(penGridThin, 475, 0, 475, 500);

			myGraf.DrawLine(penGridThin, 0, 25, 500, 25);
			myGraf.DrawLine(penGridThin, 0, 50, 500, 50);
			myGraf.DrawLine(penGridThin, 0, 75, 500, 75);
			myGraf.DrawLine(penGridThick, 0, 100, 500, 100);
			myGraf.DrawLine(penGridThin, 0, 125, 500, 125);
			myGraf.DrawLine(penGridThin, 0, 150, 500, 150);
			myGraf.DrawLine(penGridThin, 0, 175, 500, 175);
			myGraf.DrawLine(penGridThick, 0, 200, 500, 200);
			myGraf.DrawLine(penGridThin, 0, 225, 500, 225);
			myGraf.DrawLine(penGridThin, 0, 250, 500, 250);
			myGraf.DrawLine(penGridThin, 0, 275, 500, 275);
			myGraf.DrawLine(penGridThick, 0, 300, 500, 300);
			myGraf.DrawLine(penGridThin, 0, 325, 500, 325);
			myGraf.DrawLine(penGridThin, 0, 350, 500, 350);
			myGraf.DrawLine(penGridThin, 0, 375, 500, 375);
			myGraf.DrawLine(penGridThick, 0, 400, 500, 400);
			myGraf.DrawLine(penGridThin, 0, 425, 500, 425);
			myGraf.DrawLine(penGridThin, 0, 450, 500, 450);
			myGraf.DrawLine(penGridThin, 0, 475, 500, 475);
		}

		void DrawSquare(float myScale)
		{
			Pen penSquare = new Pen(Color.DarkRed, 3);
			if (myScale < 100)
			{
				float posXY = 250 - (225 * myScale / 90);
				float WidthHeight = myScale * 50 / 10;
				myGraf.DrawRectangle(penSquare, posXY, posXY, WidthHeight, WidthHeight);
			}
		}

		void pictureBox1_MouseEnter(object sender, EventArgs e)
		{
			this.KeyPreview = true;
		}

		void pictureBox1_MouseLeave(object sender, EventArgs e)
		{
			this.KeyPreview = false;
			keyCTRL = false;
		}

		void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.ControlKey)
				keyCTRL = true;
		}

		void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			keyCTRL = false;
		}

		private int Peresech(int RowTopPred, int RowForMoveTop, int RowTopSled, float newDecartX, float newDecartY)
		{
			bool var_1 = false;
			bool var_2 = false;
			const float eps = 0.001F;
			//Вариант 1
			float[,] MyTable_Var_1 = new float[4, 2];
			MyTable_Var_1[0, 0] = MyTable[RowTopPred, 0]; MyTable_Var_1[0, 1] = MyTable[RowTopPred, 1];
			MyTable_Var_1[1, 0] = newDecartX; MyTable_Var_1[1, 1] = newDecartY;
			MyTable_Var_1[2, 0] = MyTable[RowForMoveTop, 0]; MyTable_Var_1[2, 1] = MyTable[RowForMoveTop, 1];
			MyTable_Var_1[3, 0] = MyTable[RowTopSled, 0]; MyTable_Var_1[3, 1] = MyTable[RowTopSled, 1];

			float[,] MyTableLines_Var_1 = new float[MyTable_Var_1.GetLength(0) + 1, MyTable_Var_1.GetLength(1)];
			for (int i = 0; i < MyTableLines_Var_1.GetLength(0); i++)
				if (i != MyTableLines_Var_1.GetUpperBound(0))
				{
					MyTableLines_Var_1[i, 0] = MyTable_Var_1[i, 0];
					MyTableLines_Var_1[i, 1] = MyTable_Var_1[i, 1];
				}
				else
				{
					MyTableLines_Var_1[i, 0] = MyTable_Var_1[0, 0];
					MyTableLines_Var_1[i, 1] = MyTable_Var_1[0, 1];
				}

			float znamenatel_var_1, chislitelUA_var_1, chislitelUB_var_1;
			float x1_var_1, y1_var_1, x2_var_1, y2_var_1, x3_var_1, y3_var_1, x4_var_1, y4_var_1;
			for (int i = 0; i <= MyTable_Var_1.GetUpperBound(0) - 2; i++)
				for (int j = i + 1; j <= MyTable_Var_1.GetUpperBound(0) - 1; j++)
				{
					x1_var_1 = MyTableLines_Var_1[i, 0]; y1_var_1 = MyTableLines_Var_1[i, 1];
					x2_var_1 = MyTableLines_Var_1[i + 1, 0]; y2_var_1 = MyTableLines_Var_1[i + 1, 1];
					x3_var_1 = MyTableLines_Var_1[j, 0]; y3_var_1 = MyTableLines_Var_1[j, 1];
					x4_var_1 = MyTableLines_Var_1[j + 1, 0]; y4_var_1 = MyTableLines_Var_1[j + 1, 1];
					znamenatel_var_1 = (y4_var_1 - y3_var_1) * (x2_var_1 - x1_var_1) - (x4_var_1 - x3_var_1) * (y2_var_1 - y1_var_1);
					chislitelUA_var_1 = (x4_var_1 - x3_var_1) * (y1_var_1 - y3_var_1) - (y4_var_1 - y3_var_1) * (x1_var_1 - x3_var_1);
					chislitelUB_var_1 = (x2_var_1 - x1_var_1) * (y1_var_1 - y3_var_1) - (y2_var_1 - y1_var_1) * (x1_var_1 - x3_var_1);

					if (Math.Abs(znamenatel_var_1) > eps)
					{
						float UA_var_1 = chislitelUA_var_1 / znamenatel_var_1;
						float UB_var_1 = chislitelUB_var_1 / znamenatel_var_1;
						if (0 + eps < UA_var_1 && UA_var_1 < 1 - eps && 0 + eps < UB_var_1 && UB_var_1 < 1 - eps)
							var_1 = true;
					}
				}

			//Вариант 2
			float[,] MyTable_Var_2 = new float[4, 2];
			MyTable_Var_2[0, 0] = MyTable[RowTopPred, 0]; MyTable_Var_2[0, 1] = MyTable[RowTopPred, 1];
			MyTable_Var_2[1, 0] = MyTable[RowForMoveTop, 0]; MyTable_Var_2[1, 1] = MyTable[RowForMoveTop, 1];
			MyTable_Var_2[2, 0] = newDecartX; MyTable_Var_2[2, 1] = newDecartY;
			MyTable_Var_2[3, 0] = MyTable[RowTopSled, 0]; MyTable_Var_2[3, 1] = MyTable[RowTopSled, 1];

			float[,] MyTableLines_Var_2 = new float[MyTable_Var_2.GetLength(0) + 1, MyTable_Var_2.GetLength(1)];
			for (int i = 0; i < MyTableLines_Var_2.GetLength(0); i++)
				if (i != MyTableLines_Var_2.GetUpperBound(0))
				{
					MyTableLines_Var_2[i, 0] = MyTable_Var_2[i, 0];
					MyTableLines_Var_2[i, 1] = MyTable_Var_2[i, 1];
				}
				else
				{
					MyTableLines_Var_2[i, 0] = MyTable_Var_2[0, 0];
					MyTableLines_Var_2[i, 1] = MyTable_Var_2[0, 1];
				}

			float znamenatel_var_2, chislitelUA_var_2, chislitelUB_var_2;
			float x1_var_2, y1_var_2, x2_var_2, y2_var_2, x3_var_2, y3_var_2, x4_var_2, y4_var_2;
			for (int i = 0; i <= MyTable_Var_2.GetUpperBound(0) - 2; i++)
				for (int j = i + 1; j <= MyTable_Var_2.GetUpperBound(0) - 1; j++)
				{
					x1_var_2 = MyTableLines_Var_2[i, 0]; y1_var_2 = MyTableLines_Var_2[i, 1];
					x2_var_2 = MyTableLines_Var_2[i + 1, 0]; y2_var_2 = MyTableLines_Var_2[i + 1, 1];
					x3_var_2 = MyTableLines_Var_2[j, 0]; y3_var_2 = MyTableLines_Var_2[j, 1];
					x4_var_2 = MyTableLines_Var_2[j + 1, 0]; y4_var_2 = MyTableLines_Var_2[j + 1, 1];
					znamenatel_var_2 = (y4_var_2 - y3_var_2) * (x2_var_2 - x1_var_2) - (x4_var_2 - x3_var_2) * (y2_var_2 - y1_var_2);
					chislitelUA_var_2 = (x4_var_2 - x3_var_2) * (y1_var_2 - y3_var_2) - (y4_var_2 - y3_var_2) * (x1_var_2 - x3_var_2);
					chislitelUB_var_2 = (x2_var_2 - x1_var_2) * (y1_var_2 - y3_var_2) - (y2_var_2 - y1_var_2) * (x1_var_2 - x3_var_2);

					if (Math.Abs(znamenatel_var_2) > eps)
					{
						float UA_var_2 = chislitelUA_var_2 / znamenatel_var_2;
						float UB_var_2 = chislitelUB_var_2 / znamenatel_var_2;
						if (0 + eps < UA_var_2 && UA_var_2 < 1 - eps && 0 + eps < UB_var_2 && UB_var_2 < 1 - eps)
							var_2 = true;
					}
				}
			//Итог
			if (!var_1 && var_2)
				return 1;
			else if (var_1 && !var_2)
				return 2;
			else if (!var_1 && !var_2)
				return 3;
			else
				return 0;
		}		
		
		void pictureBox1_MouseClick(object sender, MouseEventArgs e)
		{
			try
			{
				if (e.Button == MouseButtons.Left && keyCTRL && !MoveTop && labelSquare2.Text != "0")
				{
					rowInsWithMouse = true;
					float Top, newDecartX, newDecartY;
					RowForMoveTop = 0;
					if (!changeScale)
					{
						newDecartX = e.X * Length_Square_metre / Length_Square_pixel;
						newDecartY = Length_Square_metre - e.Y * Length_Square_metre / Length_Square_pixel;
					}
					else
					{
						int deltaPosX = e.X - pos[RowForMoveTop].X;
						int deltaPosY = e.Y - pos[RowForMoveTop].Y;
						newDecartX = posNotScale[RowForMoveTop].X * Length_Square_metre / Length_Square_pixel + deltaPosX * (Length_Square_metre * 100 / myScale) / Length_Square_pixel;
						newDecartY = posNotScale[RowForMoveTop].Y * Length_Square_metre / Length_Square_pixel + deltaPosY * (Length_Square_metre * 100 / myScale) / Length_Square_pixel;
						newDecartY = Length_Square_metre - newDecartY;
					}
					float Top1 = (float)Math.Sqrt(Math.Pow(MyTable[0, 0] - newDecartX, 2) + Math.Pow(MyTable[0, 1] - newDecartY, 2));
					for (int i = 0; i < MyTable.GetLength(0); i++)
					{
						Top = (float)Math.Sqrt(Math.Pow(MyTable[i, 0] - newDecartX, 2) + Math.Pow(MyTable[i, 1] - newDecartY, 2));
						if (Top < Top1)
						{
							Top1 = Top;
							RowForMoveTop = i;
						}
					}
					int RowTopPred, RowTopSled;
					if (RowForMoveTop == 0)
					{
						RowTopPred = MyTable.GetUpperBound(0);
						RowTopSled = 1;
					}
					else if (RowForMoveTop == MyTable.GetUpperBound(0))
					{
						RowTopPred = RowForMoveTop - 1;
						RowTopSled = 0;
					}
					else
					{
						RowTopPred = RowForMoveTop - 1;
						RowTopSled = RowForMoveTop + 1;
					}

					int var_variant = 0;
					int variant = Peresech(RowTopPred, RowForMoveTop, RowTopSled, newDecartX, newDecartY);
					if (variant == 1)
					{
						var_variant = 1;
						RowTopSled = RowForMoveTop;						
					}
					else if (variant == 2)
					{
						var_variant = 2;
						RowTopPred = RowForMoveTop;
						RowForMoveTop = RowTopSled;						
					}
					//Var 1_1
					else if (variant == 3 && MyTable[RowTopPred, 0] < MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] < MyTable[RowForMoveTop, 1] && MyTable[RowForMoveTop, 0] < MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] < MyTable[RowTopSled, 1])
 					{
						if (MyTable[RowTopPred, 0] < newDecartX && newDecartX < MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] < newDecartY && newDecartY < MyTable[RowForMoveTop, 1] && (newDecartX < MyTable[RowForMoveTop, 0] || MyTable[RowTopSled, 0] < newDecartX || newDecartY < MyTable[RowForMoveTop, 1] || MyTable[RowTopSled, 1] < newDecartY))
						{
							var_variant = 1;
							RowTopSled = RowForMoveTop;
						}
						if (MyTable[RowForMoveTop, 0] < newDecartX && newDecartX < MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] < newDecartY && newDecartY < MyTable[RowTopSled, 1] && (newDecartX < MyTable[RowTopPred, 0] || MyTable[RowForMoveTop, 0] < newDecartX || newDecartY < MyTable[RowTopPred, 1] || MyTable[RowForMoveTop, 1] < newDecartY))
						{
							var_variant = 2;
							RowTopPred = RowForMoveTop;
							RowForMoveTop = RowTopSled;
						}
					}
					//Var 1_2
					else if (variant == 3 && MyTable[RowTopPred, 0] < MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] < MyTable[RowForMoveTop, 1] && MyTable[RowForMoveTop, 0] < MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] > MyTable[RowTopSled, 1])
					{
						if (MyTable[RowTopPred, 0] < newDecartX && newDecartX < MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] < newDecartY && newDecartY < MyTable[RowForMoveTop, 1] && (newDecartX < MyTable[RowForMoveTop, 0] || MyTable[RowTopSled, 0] < newDecartX || newDecartY > MyTable[RowForMoveTop, 1] || MyTable[RowTopSled, 1] > newDecartY))
						{
							var_variant = 1;
							RowTopSled = RowForMoveTop;
						}
						if (MyTable[RowForMoveTop, 0] < newDecartX && newDecartX < MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] > newDecartY && newDecartY > MyTable[RowTopSled, 1] && (newDecartX < MyTable[RowTopPred, 0] || MyTable[RowForMoveTop, 0] < newDecartX || newDecartY < MyTable[RowTopPred, 1] || MyTable[RowForMoveTop, 1] < newDecartY))
						{
							var_variant = 2;
							RowTopPred = RowForMoveTop;
							RowForMoveTop = RowTopSled;
						}
					}
					//Var 1_3
					else if (variant == 3 && MyTable[RowTopPred, 0] < MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] < MyTable[RowForMoveTop, 1] && MyTable[RowForMoveTop, 0] > MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] > MyTable[RowTopSled, 1])
					{
						if (MyTable[RowTopPred, 0] < newDecartX && newDecartX < MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] < newDecartY && newDecartY < MyTable[RowForMoveTop, 1] && (newDecartX > MyTable[RowForMoveTop, 0] || MyTable[RowTopSled, 0] > newDecartX || newDecartY > MyTable[RowForMoveTop, 1] || MyTable[RowTopSled, 1] > newDecartY))
						{
							var_variant = 1;
							RowTopSled = RowForMoveTop;
						}
						if (MyTable[RowForMoveTop, 0] > newDecartX && newDecartX > MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] > newDecartY && newDecartY > MyTable[RowTopSled, 1] && (newDecartX < MyTable[RowTopPred, 0] || MyTable[RowForMoveTop, 0] < newDecartX || newDecartY < MyTable[RowTopPred, 1] || MyTable[RowForMoveTop, 1] < newDecartY))
						{
							var_variant = 2;
							RowTopPred = RowForMoveTop;
							RowForMoveTop = RowTopSled;
						}
					}
					//Var 1_4
					else if (variant == 3 && MyTable[RowTopPred, 0] < MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] < MyTable[RowForMoveTop, 1] && MyTable[RowForMoveTop, 0] > MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] < MyTable[RowTopSled, 1])
					{
						if (MyTable[RowTopPred, 0] < newDecartX && newDecartX < MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] < newDecartY && newDecartY < MyTable[RowForMoveTop, 1] && (newDecartX > MyTable[RowForMoveTop, 0] || MyTable[RowTopSled, 0] > newDecartX || newDecartY < MyTable[RowForMoveTop, 1] || MyTable[RowTopSled, 1] < newDecartY))
						{
							var_variant = 1;
							RowTopSled = RowForMoveTop;
						}
						if (MyTable[RowForMoveTop, 0] > newDecartX && newDecartX > MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] < newDecartY && newDecartY < MyTable[RowTopSled, 1] && (newDecartX < MyTable[RowTopPred, 0] || MyTable[RowForMoveTop, 0] < newDecartX || newDecartY < MyTable[RowTopPred, 1] || MyTable[RowForMoveTop, 1] < newDecartY))
						{
							var_variant = 2;
							RowTopPred = RowForMoveTop;
							RowForMoveTop = RowTopSled;
						}
					}
					//Var 2_1
					else if (variant == 3 && MyTable[RowTopPred, 0] < MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] > MyTable[RowForMoveTop, 1] && MyTable[RowForMoveTop, 0] < MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] < MyTable[RowTopSled, 1])
					{
						if (MyTable[RowTopPred, 0] < newDecartX && newDecartX < MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] > newDecartY && newDecartY > MyTable[RowForMoveTop, 1] && (newDecartX < MyTable[RowForMoveTop, 0] || MyTable[RowTopSled, 0] < newDecartX || newDecartY < MyTable[RowForMoveTop, 1] || MyTable[RowTopSled, 1] < newDecartY))
						{
							var_variant = 1;
							RowTopSled = RowForMoveTop;
						}
						if (MyTable[RowForMoveTop, 0] < newDecartX && newDecartX < MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] < newDecartY && newDecartY < MyTable[RowTopSled, 1] && (newDecartX < MyTable[RowTopPred, 0] || MyTable[RowForMoveTop, 0] < newDecartX || newDecartY > MyTable[RowTopPred, 1] || MyTable[RowForMoveTop, 1] > newDecartY))
						{
							var_variant = 2;
							RowTopPred = RowForMoveTop;
							RowForMoveTop = RowTopSled;
						}
					}
					//Var 2_2
					else if (variant == 3 && MyTable[RowTopPred, 0] < MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] > MyTable[RowForMoveTop, 1] && MyTable[RowForMoveTop, 0] < MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] > MyTable[RowTopSled, 1])
					{
						if (MyTable[RowTopPred, 0] < newDecartX && newDecartX < MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] > newDecartY && newDecartY > MyTable[RowForMoveTop, 1] && (newDecartX < MyTable[RowForMoveTop, 0] || MyTable[RowTopSled, 0] < newDecartX || newDecartY > MyTable[RowForMoveTop, 1] || MyTable[RowTopSled, 1] > newDecartY))
						{
							var_variant = 1;
							RowTopSled = RowForMoveTop;
						}
						if (MyTable[RowForMoveTop, 0] < newDecartX && newDecartX < MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] > newDecartY && newDecartY > MyTable[RowTopSled, 1] && (newDecartX < MyTable[RowTopPred, 0] || MyTable[RowForMoveTop, 0] < newDecartX || newDecartY > MyTable[RowTopPred, 1] || MyTable[RowForMoveTop, 1] > newDecartY))
						{
							var_variant = 2;
							RowTopPred = RowForMoveTop;
							RowForMoveTop = RowTopSled;
						}
					}
					//Var 2_3
					else if (variant == 3 && MyTable[RowTopPred, 0] < MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] > MyTable[RowForMoveTop, 1] && MyTable[RowForMoveTop, 0] > MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] > MyTable[RowTopSled, 1])
					{
						if (MyTable[RowTopPred, 0] < newDecartX && newDecartX < MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] > newDecartY && newDecartY > MyTable[RowForMoveTop, 1] && (newDecartX > MyTable[RowForMoveTop, 0] || MyTable[RowTopSled, 0] > newDecartX || newDecartY > MyTable[RowForMoveTop, 1] || MyTable[RowTopSled, 1] > newDecartY))
						{
							var_variant = 1;
							RowTopSled = RowForMoveTop;
						}
						if (MyTable[RowForMoveTop, 0] > newDecartX && newDecartX > MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] > newDecartY && newDecartY > MyTable[RowTopSled, 1] && (newDecartX < MyTable[RowTopPred, 0] || MyTable[RowForMoveTop, 0] < newDecartX || newDecartY > MyTable[RowTopPred, 1] || MyTable[RowForMoveTop, 1] > newDecartY))
						{
							var_variant = 2;
							RowTopPred = RowForMoveTop;
							RowForMoveTop = RowTopSled;
						}
					}
					//Var 2_4
					else if (variant == 3 && MyTable[RowTopPred, 0] < MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] > MyTable[RowForMoveTop, 1] && MyTable[RowForMoveTop, 0] > MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] < MyTable[RowTopSled, 1])
					{
						if (MyTable[RowTopPred, 0] < newDecartX && newDecartX < MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] > newDecartY && newDecartY > MyTable[RowForMoveTop, 1] && (newDecartX > MyTable[RowForMoveTop, 0] || MyTable[RowTopSled, 0] > newDecartX || newDecartY < MyTable[RowForMoveTop, 1] || MyTable[RowTopSled, 1] < newDecartY))
						{
							var_variant = 1;
							RowTopSled = RowForMoveTop;
						}
						if (MyTable[RowForMoveTop, 0] > newDecartX && newDecartX > MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] < newDecartY && newDecartY < MyTable[RowTopSled, 1] && (newDecartX < MyTable[RowTopPred, 0] || MyTable[RowForMoveTop, 0] < newDecartX || newDecartY > MyTable[RowTopPred, 1] || MyTable[RowForMoveTop, 1] > newDecartY))
						{
							var_variant = 2;
							RowTopPred = RowForMoveTop;
							RowForMoveTop = RowTopSled;
						}
					}
					//Var 3_1
					else if (variant == 3 && MyTable[RowTopPred, 0] > MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] > MyTable[RowForMoveTop, 1] && MyTable[RowForMoveTop, 0] < MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] < MyTable[RowTopSled, 1])
					{
						if (MyTable[RowTopPred, 0] > newDecartX && newDecartX > MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] > newDecartY && newDecartY > MyTable[RowForMoveTop, 1] && (newDecartX < MyTable[RowForMoveTop, 0] || MyTable[RowTopSled, 0] < newDecartX || newDecartY < MyTable[RowForMoveTop, 1] || MyTable[RowTopSled, 1] < newDecartY))
						{
							var_variant = 1;
							RowTopSled = RowForMoveTop;
						}
						if (MyTable[RowForMoveTop, 0] < newDecartX && newDecartX < MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] < newDecartY && newDecartY < MyTable[RowTopSled, 1] && (newDecartX > MyTable[RowTopPred, 0] || MyTable[RowForMoveTop, 0] > newDecartX || newDecartY > MyTable[RowTopPred, 1] || MyTable[RowForMoveTop, 1] > newDecartY))
						{
							var_variant = 2;
							RowTopPred = RowForMoveTop;
							RowForMoveTop = RowTopSled;
						}
					}
					//Var 3_2
					else if (variant == 3 && MyTable[RowTopPred, 0] > MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] > MyTable[RowForMoveTop, 1] && MyTable[RowForMoveTop, 0] < MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] > MyTable[RowTopSled, 1])
					{
						if (MyTable[RowTopPred, 0] > newDecartX && newDecartX > MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] > newDecartY && newDecartY > MyTable[RowForMoveTop, 1] && (newDecartX < MyTable[RowForMoveTop, 0] || MyTable[RowTopSled, 0] < newDecartX || newDecartY > MyTable[RowForMoveTop, 1] || MyTable[RowTopSled, 1] > newDecartY))
						{
							var_variant = 1;
							RowTopSled = RowForMoveTop;
						}
						if (MyTable[RowForMoveTop, 0] < newDecartX && newDecartX < MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] > newDecartY && newDecartY > MyTable[RowTopSled, 1] && (newDecartX > MyTable[RowTopPred, 0] || MyTable[RowForMoveTop, 0] > newDecartX || newDecartY > MyTable[RowTopPred, 1] || MyTable[RowForMoveTop, 1] > newDecartY))
						{
							var_variant = 2;
							RowTopPred = RowForMoveTop;
							RowForMoveTop = RowTopSled;
						}
					}
					//Var 3_3
					else if (variant == 3 && MyTable[RowTopPred, 0] > MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] > MyTable[RowForMoveTop, 1] && MyTable[RowForMoveTop, 0] > MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] > MyTable[RowTopSled, 1])
					{
						if (MyTable[RowTopPred, 0] > newDecartX && newDecartX > MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] > newDecartY && newDecartY > MyTable[RowForMoveTop, 1] && (newDecartX > MyTable[RowForMoveTop, 0] || MyTable[RowTopSled, 0] > newDecartX || newDecartY > MyTable[RowForMoveTop, 1] || MyTable[RowTopSled, 1] > newDecartY))
						{
							var_variant = 1;
							RowTopSled = RowForMoveTop;
						}
						if (MyTable[RowForMoveTop, 0] > newDecartX && newDecartX > MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] > newDecartY && newDecartY > MyTable[RowTopSled, 1] && (newDecartX > MyTable[RowTopPred, 0] || MyTable[RowForMoveTop, 0] > newDecartX || newDecartY > MyTable[RowTopPred, 1] || MyTable[RowForMoveTop, 1] > newDecartY))
						{
							var_variant = 2;
							RowTopPred = RowForMoveTop;
							RowForMoveTop = RowTopSled;
						}
					}
					//Var 3_4
					else if (variant == 3 && MyTable[RowTopPred, 0] > MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] > MyTable[RowForMoveTop, 1] && MyTable[RowForMoveTop, 0] > MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] < MyTable[RowTopSled, 1])
					{
						if (MyTable[RowTopPred, 0] > newDecartX && newDecartX > MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] > newDecartY && newDecartY > MyTable[RowForMoveTop, 1] && (newDecartX > MyTable[RowForMoveTop, 0] || MyTable[RowTopSled, 0] > newDecartX || newDecartY < MyTable[RowForMoveTop, 1] || MyTable[RowTopSled, 1] < newDecartY))
						{
							var_variant = 1;
							RowTopSled = RowForMoveTop;
						}
						if (MyTable[RowForMoveTop, 0] > newDecartX && newDecartX > MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] < newDecartY && newDecartY < MyTable[RowTopSled, 1] && (newDecartX > MyTable[RowTopPred, 0] || MyTable[RowForMoveTop, 0] > newDecartX || newDecartY > MyTable[RowTopPred, 1] || MyTable[RowForMoveTop, 1] > newDecartY))
						{
							var_variant = 2;
							RowTopPred = RowForMoveTop;
							RowForMoveTop = RowTopSled;
						}
					}
					//Var 4_1
					else if (variant == 3 && MyTable[RowTopPred, 0] > MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] < MyTable[RowForMoveTop, 1] && MyTable[RowForMoveTop, 0] < MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] < MyTable[RowTopSled, 1])
					{
						if (MyTable[RowTopPred, 0] > newDecartX && newDecartX > MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] < newDecartY && newDecartY < MyTable[RowForMoveTop, 1] && (newDecartX < MyTable[RowForMoveTop, 0] || MyTable[RowTopSled, 0] < newDecartX || newDecartY < MyTable[RowForMoveTop, 1] || MyTable[RowTopSled, 1] < newDecartY))
						{
							var_variant = 1;
							RowTopSled = RowForMoveTop;
						}
						if (MyTable[RowForMoveTop, 0] < newDecartX && newDecartX < MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] < newDecartY && newDecartY < MyTable[RowTopSled, 1] && (newDecartX > MyTable[RowTopPred, 0] || MyTable[RowForMoveTop, 0] > newDecartX || newDecartY < MyTable[RowTopPred, 1] || MyTable[RowForMoveTop, 1] < newDecartY))
						{
							var_variant = 2;
							RowTopPred = RowForMoveTop;
							RowForMoveTop = RowTopSled;
						}
					}
					//Var 4_2
					else if (variant == 3 && MyTable[RowTopPred, 0] > MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] < MyTable[RowForMoveTop, 1] && MyTable[RowForMoveTop, 0] < MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] > MyTable[RowTopSled, 1])
					{
						if (MyTable[RowTopPred, 0] > newDecartX && newDecartX > MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] < newDecartY && newDecartY < MyTable[RowForMoveTop, 1] && (newDecartX < MyTable[RowForMoveTop, 0] || MyTable[RowTopSled, 0] < newDecartX || newDecartY > MyTable[RowForMoveTop, 1] || MyTable[RowTopSled, 1] > newDecartY))
						{
							var_variant = 1;
							RowTopSled = RowForMoveTop;
						}
						if (MyTable[RowForMoveTop, 0] < newDecartX && newDecartX < MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] > newDecartY && newDecartY > MyTable[RowTopSled, 1] && (newDecartX > MyTable[RowTopPred, 0] || MyTable[RowForMoveTop, 0] > newDecartX || newDecartY < MyTable[RowTopPred, 1] || MyTable[RowForMoveTop, 1] < newDecartY))
						{
							var_variant = 2;
							RowTopPred = RowForMoveTop;
							RowForMoveTop = RowTopSled;
						}
					}
					//Var 4_3
					else if (variant == 3 && MyTable[RowTopPred, 0] > MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] < MyTable[RowForMoveTop, 1] && MyTable[RowForMoveTop, 0] > MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] > MyTable[RowTopSled, 1])
					{
						if (MyTable[RowTopPred, 0] > newDecartX && newDecartX > MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] < newDecartY && newDecartY < MyTable[RowForMoveTop, 1] && (newDecartX > MyTable[RowForMoveTop, 0] || MyTable[RowTopSled, 0] > newDecartX || newDecartY > MyTable[RowForMoveTop, 1] || MyTable[RowTopSled, 1] > newDecartY))
						{
							var_variant = 1;
							RowTopSled = RowForMoveTop;
						}
						if (MyTable[RowForMoveTop, 0] > newDecartX && newDecartX > MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] > newDecartY && newDecartY > MyTable[RowTopSled, 1] && (newDecartX > MyTable[RowTopPred, 0] || MyTable[RowForMoveTop, 0] > newDecartX || newDecartY < MyTable[RowTopPred, 1] || MyTable[RowForMoveTop, 1] < newDecartY))
						{
							var_variant = 2;
							RowTopPred = RowForMoveTop;
							RowForMoveTop = RowTopSled;
						}
					}
					//Var 4_4
					else if (variant == 3 && MyTable[RowTopPred, 0] > MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] < MyTable[RowForMoveTop, 1] && MyTable[RowForMoveTop, 0] > MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] < MyTable[RowTopSled, 1])
					{
						if (MyTable[RowTopPred, 0] > newDecartX && newDecartX > MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] < newDecartY && newDecartY < MyTable[RowForMoveTop, 1] && (newDecartX > MyTable[RowForMoveTop, 0] || MyTable[RowTopSled, 0] > newDecartX || newDecartY < MyTable[RowForMoveTop, 1] || MyTable[RowTopSled, 1] < newDecartY))
						{
							var_variant = 1;
							RowTopSled = RowForMoveTop;
						}
						if (MyTable[RowForMoveTop, 0] > newDecartX && newDecartX > MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] < newDecartY && newDecartY < MyTable[RowTopSled, 1] && (newDecartX > MyTable[RowTopPred, 0] || MyTable[RowForMoveTop, 0] > newDecartX || newDecartY < MyTable[RowTopPred, 1] || MyTable[RowForMoveTop, 1] < newDecartY))
						{
							var_variant = 2;
							RowTopPred = RowForMoveTop;
							RowForMoveTop = RowTopSled;
						}
					}
					if (var_variant == 0)
					{
						float TopPred = (float)Math.Sqrt(Math.Pow(MyTable[RowTopPred, 0] - newDecartX, 2) + Math.Pow(MyTable[RowTopPred, 1] - newDecartY, 2));
						float TopSled = (float)Math.Sqrt(Math.Pow(MyTable[RowTopSled, 0] - newDecartX, 2) + Math.Pow(MyTable[RowTopSled, 1] - newDecartY, 2));
						if (TopPred < TopSled)
						{
							var_variant = 1;
							RowTopSled = RowForMoveTop;
						}
						else
						{
							var_variant = 2;
							RowTopPred = RowForMoveTop;
							RowForMoveTop = RowTopSled;
						}
						//RowTopSled++;
					}
					//Выполняем дополнительную проверку
					int RowTopPred_2 = 0;
					int RowForMoveTop_2 = 0;
					int RowTopSled_2 = 0;
					if (var_variant == 1)
					{
						RowTopSled_2 = RowForMoveTop;
						RowForMoveTop_2 = RowTopPred;
						if (RowTopPred == 0)
							RowTopPred_2 = MyTable.GetUpperBound(0);
						else
							RowTopPred_2 = RowTopPred - 1;						
					}
					else if (var_variant == 2)
					{
						RowTopPred_2 = RowTopPred;
						RowForMoveTop_2 = RowForMoveTop;
						if (RowForMoveTop == MyTable.GetUpperBound(0))
							RowTopSled_2 = 0;
						else
							RowTopSled_2 = RowForMoveTop + 1;						
					}
					variant = Peresech(RowTopPred_2, RowForMoveTop_2, RowTopSled_2, newDecartX, newDecartY);
					if (variant == 1)
					{
						RowTopPred = RowTopPred_2;
						RowForMoveTop = RowForMoveTop_2;
						RowTopSled = RowForMoveTop_2;						
					}
					else if (variant == 2)
					{
						RowTopPred = RowForMoveTop_2;
						RowForMoveTop = RowTopSled_2;
						RowTopSled = RowTopSled_2;
					}

					//Выполняем вставку вершины
					keyInsert = true;
					MoveTop = false;
					moveTop = false;
					ClearLines();
					labelLengthAll.Text = "0";
					labelLengthSegment.Text = "0";
					try
					{
						if (myDataTable.Rows.Count != 0)
						{
							for (int i = 0; i < myDataTable.Rows.Count; i++)
								if (myDataTable.Rows[i][1].ToString() == "" && myDataTable.Rows[i][2].ToString() == "")
									myDataTable.Rows[i].Delete();
						}
						if (rowPeresech_1 != -1 && rowPeresech_2 != -1)
						{
							dataGridView1.Rows[rowPeresech_1].DefaultCellStyle.BackColor = cellBackColor;
							dataGridView1.Rows[rowPeresech_2].DefaultCellStyle.BackColor = cellBackColor;
							rowPeresech_1 = -1; rowPeresech_2 = -1;
						}
						DataRow newRow = myDataTable.NewRow();
						myDataTable.Rows.InsertAt(newRow, RowForMoveTop);
						myDataTable.Rows[RowForMoveTop][1] = 360;
						myDataTable.Rows[RowForMoveTop][2] = 0;
						dataGridView1.Refresh();
					}
					catch (Exception ex)
					{
						result = MessageBox.Show(ex.Message, "Системная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					keyInsert = false;

					double a1, b1, c1, alfa1, a2, b2, c2, alfa2;
					a1 = Math.Abs(newDecartX - MyTable[RowTopPred, 0]);
					b1 = Math.Abs(newDecartY - MyTable[RowTopPred, 1]);
					c1 = Math.Sqrt(Math.Pow(a1, 2) + Math.Pow(b1, 2));
					a2 = Math.Abs(MyTable[RowTopSled, 0] - newDecartX);
					b2 = Math.Abs(MyTable[RowTopSled, 1] - newDecartY);
					c2 = Math.Sqrt(Math.Pow(a2, 2) + Math.Pow(b2, 2));
					if (MyTable[RowTopPred, 0] == newDecartX && MyTable[RowTopPred, 1] < newDecartY)
					{
						if (RowTopPred != MyTable.GetUpperBound(0))
						{
							dataGridView1.Rows[RowTopPred].Cells[1].Value = 0;
							dataGridView1.Rows[RowTopPred].Cells[2].Value = Math.Round(b1, 2);
						}
					}
					if (newDecartX == MyTable[RowTopSled, 0] && newDecartY < MyTable[RowTopSled, 1])
					{
						dataGridView1.Rows[RowForMoveTop].Cells[1].Value = 0;
						dataGridView1.Rows[RowForMoveTop].Cells[2].Value = Math.Round(b2, 2);
					}

					if (MyTable[RowTopPred, 0] < newDecartX && MyTable[RowTopPred, 1] < newDecartY)
					{
						alfa1 = Math.Acos(b1 / c1) * 180 / Math.PI;
						if (RowTopPred != MyTable.GetUpperBound(0))
						{
							dataGridView1.Rows[RowTopPred].Cells[1].Value = Math.Round(alfa1, 2);
							dataGridView1.Rows[RowTopPred].Cells[2].Value = Math.Round(c1, 2);
						}
					}
					if (newDecartX < MyTable[RowTopSled, 0] && newDecartY < MyTable[RowTopSled, 1])
					{
						alfa2 = Math.Acos(b2 / c2) * 180 / Math.PI;
						dataGridView1.Rows[RowForMoveTop].Cells[1].Value = Math.Round(alfa2, 2);
						dataGridView1.Rows[RowForMoveTop].Cells[2].Value = Math.Round(c2, 2);
					}

					if (MyTable[RowTopPred, 0] < newDecartX && MyTable[RowTopPred, 1] == newDecartY)
					{
						if (RowTopPred != MyTable.GetUpperBound(0))
						{
							dataGridView1.Rows[RowTopPred].Cells[1].Value = 90;
							dataGridView1.Rows[RowTopPred].Cells[2].Value = Math.Round(a1, 2);
						}
					}
					if (newDecartX < MyTable[RowTopSled, 0] && newDecartY == MyTable[RowTopSled, 1])
					{
						dataGridView1.Rows[RowForMoveTop].Cells[1].Value = 90;
						dataGridView1.Rows[RowForMoveTop].Cells[2].Value = Math.Round(a2, 2);
					}

					if (MyTable[RowTopPred, 0] < newDecartX && MyTable[RowTopPred, 1] > newDecartY)
					{
						alfa1 = Math.Acos(a1 / c1) * 180 / Math.PI;
						if (RowTopPred != MyTable.GetUpperBound(0))
						{
							dataGridView1.Rows[RowTopPred].Cells[1].Value = Math.Round(alfa1, 2) + 90;
							dataGridView1.Rows[RowTopPred].Cells[2].Value = Math.Round(c1, 2);
						}
					}
					if (newDecartX < MyTable[RowTopSled, 0] && newDecartY > MyTable[RowTopSled, 1])
					{
						alfa2 = Math.Acos(a2 / c2) * 180 / Math.PI;
						dataGridView1.Rows[RowForMoveTop].Cells[1].Value = Math.Round(alfa2, 2) + 90;
						dataGridView1.Rows[RowForMoveTop].Cells[2].Value = Math.Round(c2, 2);
					}

					if (MyTable[RowTopPred, 0] == newDecartX && MyTable[RowTopPred, 1] > newDecartY)
					{
						if (RowTopPred != MyTable.GetUpperBound(0))
						{
							dataGridView1.Rows[RowTopPred].Cells[1].Value = 180;
							dataGridView1.Rows[RowTopPred].Cells[2].Value = Math.Round(b1, 2);
						}
					}
					if (newDecartX == MyTable[RowTopSled, 0] && newDecartY > MyTable[RowTopSled, 1])
					{
						dataGridView1.Rows[RowForMoveTop].Cells[1].Value = 180;
						dataGridView1.Rows[RowForMoveTop].Cells[2].Value = Math.Round(b2, 2);
					}

					if (MyTable[RowTopPred, 0] > newDecartX && MyTable[RowTopPred, 1] > newDecartY)
					{
						alfa1 = Math.Acos(b1 / c1) * 180 / Math.PI;
						if (RowTopPred != MyTable.GetUpperBound(0))
						{
							dataGridView1.Rows[RowTopPred].Cells[1].Value = Math.Round(alfa1, 2) + 180;
							dataGridView1.Rows[RowTopPred].Cells[2].Value = Math.Round(c1, 2);
						}
					}
					if (newDecartX > MyTable[RowTopSled, 0] && newDecartY > MyTable[RowTopSled, 1])
					{
						alfa2 = Math.Acos(b2 / c2) * 180 / Math.PI;
						dataGridView1.Rows[RowForMoveTop].Cells[1].Value = Math.Round(alfa2, 2) + 180;
						dataGridView1.Rows[RowForMoveTop].Cells[2].Value = Math.Round(c2, 2);
					}

					if (MyTable[RowTopPred, 0] > newDecartX && MyTable[RowTopPred, 1] == newDecartY)
					{
						if (RowTopPred != MyTable.GetUpperBound(0))
						{
							dataGridView1.Rows[RowTopPred].Cells[1].Value = 270;
							dataGridView1.Rows[RowTopPred].Cells[2].Value = Math.Round(a1, 2);
						}
					}
					if (newDecartX > MyTable[RowTopSled, 0] && newDecartY == MyTable[RowTopSled, 1])
					{
						dataGridView1.Rows[RowForMoveTop].Cells[1].Value = 270;
						dataGridView1.Rows[RowForMoveTop].Cells[2].Value = Math.Round(a2, 2);
					}

					if (MyTable[RowTopPred, 0] > newDecartX && MyTable[RowTopPred, 1] < newDecartY)
					{
						alfa1 = Math.Acos(a1 / c1) * 180 / Math.PI;
						if (RowTopPred != MyTable.GetUpperBound(0))
						{
							dataGridView1.Rows[RowTopPred].Cells[1].Value = Math.Round(alfa1, 2) + 270;
							dataGridView1.Rows[RowTopPred].Cells[2].Value = Math.Round(c1, 2);
						}
					}
					if (newDecartX > MyTable[RowTopSled, 0] && newDecartY < MyTable[RowTopSled, 1])
					{
						alfa2 = Math.Acos(a2 / c2) * 180 / Math.PI;
						dataGridView1.Rows[RowForMoveTop].Cells[1].Value = Math.Round(alfa2, 2) + 270;
						dataGridView1.Rows[RowForMoveTop].Cells[2].Value = Math.Round(c2, 2);
					}
					dataGridView1.CurrentCell.Selected = false;
					dataGridView1.Rows[RowForMoveTop].Selected = true;
					CreatePlan();
					Square();
					Perimetr();
					changeValue = false;
					rowInsWithMouse = false;
				}
				else if (e.Button == MouseButtons.Right && keyCTRL && !MoveTop && labelSquare2.Text != "0")
				{
					for (int i = 0; i < pos.Length; i++)
						if (pos[i].X - 4 <= e.X && e.X <= pos[i].X + 4 && pos[i].Y - 4 <= e.Y && e.Y <= pos[i].Y + 4)
						{
							keyDelete = true;
							RowForMoveTop = i;
							MoveTop = false;
							moveTop = false;
							ClearLines();
							labelLengthAll.Text = "0";
							labelLengthSegment.Text = "0";
							try
							{
								for (int j = 0; j < myDataTable.Rows.Count; j++)
									if (myDataTable.Rows[j][1].ToString() == "" && myDataTable.Rows[j][2].ToString() == "")
										myDataTable.Rows[j].Delete();
								if (rowPeresech_1 != -1 && rowPeresech_2 != -1)
								{
									dataGridView1.Rows[rowPeresech_1].DefaultCellStyle.BackColor = cellBackColor;
									dataGridView1.Rows[rowPeresech_2].DefaultCellStyle.BackColor = cellBackColor;
									rowPeresech_1 = -1; rowPeresech_2 = -1;
								}

								rowDel = true;
								int RowTopPred, RowTopSled;
								if (RowForMoveTop == 0)
								{
									RowTopPred = pos.Length - 1;
									RowTopSled = 1;
									dataGridView1.Rows.Remove(dataGridView1.Rows[RowForMoveTop]);
								}
								else if (RowForMoveTop == pos.Length - 1)
								{
									RowTopPred = RowForMoveTop - 1;
									RowTopSled = 0;
									dataGridView1.Rows.Remove(dataGridView1.Rows[RowForMoveTop - 1]);
								}
								else
								{
									RowTopPred = RowForMoveTop - 1;
									RowTopSled = RowForMoveTop + 1;
									double a, b, c, alfa;
									a = Math.Abs(MyTable[RowTopSled, 0] - MyTable[RowTopPred, 0]);
									b = Math.Abs(MyTable[RowTopSled, 1] - MyTable[RowTopPred, 1]);
									c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));

									if (MyTable[RowTopPred, 0] == MyTable[RowTopSled, 0] && MyTable[RowTopPred, 1] < MyTable[RowTopSled, 1])
									{
										dataGridView1.Rows[RowTopPred].Cells[1].Value = 0;
										dataGridView1.Rows[RowTopPred].Cells[2].Value = Math.Round(b, 2);
									}
									if (MyTable[RowTopPred, 0] < MyTable[RowTopSled, 0] && MyTable[RowTopPred, 1] < MyTable[RowTopSled, 1])
									{
										alfa = Math.Acos(b / c) * 180 / Math.PI;
										dataGridView1.Rows[RowTopPred].Cells[1].Value = Math.Round(alfa, 2);
										dataGridView1.Rows[RowTopPred].Cells[2].Value = Math.Round(c, 2);
									}
									if (MyTable[RowTopPred, 0] < MyTable[RowTopSled, 0] && MyTable[RowTopPred, 1] == MyTable[RowTopSled, 1])
									{
										dataGridView1.Rows[RowTopPred].Cells[1].Value = 90;
										dataGridView1.Rows[RowTopPred].Cells[2].Value = Math.Round(a, 2);
									}
									if (MyTable[RowTopPred, 0] < MyTable[RowTopSled, 0] && MyTable[RowTopPred, 1] > MyTable[RowTopSled, 1])
									{
										alfa = Math.Acos(a / c) * 180 / Math.PI;
										dataGridView1.Rows[RowTopPred].Cells[1].Value = Math.Round(alfa, 2) + 90;
										dataGridView1.Rows[RowTopPred].Cells[2].Value = Math.Round(c, 2);
									}
									if (MyTable[RowTopPred, 0] == MyTable[RowTopSled, 0] && MyTable[RowTopPred, 1] > MyTable[RowTopSled, 1])
									{
										dataGridView1.Rows[RowTopPred].Cells[1].Value = 180;
										dataGridView1.Rows[RowTopPred].Cells[2].Value = Math.Round(b, 2);
									}
									if (MyTable[RowTopPred, 0] > MyTable[RowTopSled, 0] && MyTable[RowTopPred, 1] > MyTable[RowTopSled, 1])
									{
										alfa = Math.Acos(b / c) * 180 / Math.PI;
										dataGridView1.Rows[RowTopPred].Cells[1].Value = Math.Round(alfa, 2) + 180;
										dataGridView1.Rows[RowTopPred].Cells[2].Value = Math.Round(c, 2);
									}
									if (MyTable[RowTopPred, 0] > MyTable[RowTopSled, 0] && MyTable[RowTopPred, 1] == MyTable[RowTopSled, 1])
									{
										dataGridView1.Rows[RowTopPred].Cells[1].Value = 270;
										dataGridView1.Rows[RowTopPred].Cells[2].Value = Math.Round(a, 2);
									}
									if (MyTable[RowTopPred, 0] > MyTable[RowTopSled, 0] && MyTable[RowTopPred, 1] < MyTable[RowTopSled, 1])
									{
										alfa = Math.Acos(a / c) * 180 / Math.PI;
										dataGridView1.Rows[RowTopPred].Cells[1].Value = Math.Round(alfa, 2) + 270;
										dataGridView1.Rows[RowTopPred].Cells[2].Value = Math.Round(c, 2);
									}
									dataGridView1.Rows.Remove(dataGridView1.Rows[RowForMoveTop]);
								}
								myDataTable.AcceptChanges();
								rowDel = false;

								if (myDataTable.Rows.Count > 1 && ErrorCellArray.Count == 0 && labelSquare2.Text != "0")
								{
									buttonLeft.Enabled = true;
									buttonRight.Enabled = true;
									textTurn.Enabled = true;
									butScaleMin.Enabled = true;
									butScaleMax.Enabled = true;
									textScale.Enabled = true;
									сохранитьФайлToolStripMenuItem2.Enabled = true;
									CreatePlan();
									if ((CreateMyTableSuccess || changeTurn || MoveTop))
									{
										Square();
										Perimetr();
									}
								}
								DrawPanel();
								for (int j = 0; j < myDataTable.Rows.Count; j++)
									if (myDataTable.Rows[j][1].ToString() == "" && myDataTable.Rows[j][2].ToString() == "")
										myDataTable.Rows[j].Delete();
								if (dataGridView1.Rows.Count <= 2 || (dataGridView1.Rows.Count == 3 && dataGridView1.Rows[1].Cells[1].Value.ToString() == "" && dataGridView1.Rows[1].Cells[1].Value.ToString() == ""))
									Clear();
								dataGridView1.Refresh();
								dataGridView1.CurrentCell.Selected = false;
								dataGridView1.Rows[0].Cells[1].Selected = true;
								dataGridView1.Focus();
							}
							catch (Exception ex)
							{
								result = MessageBox.Show(ex.Message, "Системная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
							keyDelete = false;
						}
				}
				else if (e.Button == MouseButtons.Right && labelSquare2.Text != "0")
					ListPoint.Add(new Point(e.X, e.Y));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n\nРЕКОМЕНДУЕТСЯ СОХРАНИТЬ ВСЕ ДАННЫЕ И ПЕРЕЗАГРУЗИТЬ ПРОГРАММУ!", "Ошибка программы", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && !MoveTop && labelSquare2.Text != "0")
				for (int i = 0; i < pos.Length; i++)
					if (pos[i].X - 4 <= e.X && e.X <= pos[i].X + 4 && pos[i].Y - 4 <= e.Y && e.Y <= pos[i].Y + 4)
					{
						RowForMoveTop = i;
						ClearLines();
						CreatePlan();
						Square();
						Perimetr();
						dataGridView1.CurrentCell.Selected = false;
						dataGridView1.Rows[i].Selected = true;
						dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[1];
						MoveTop = true;
					}
		}

		void pictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			MoveTop = false;
			//if (CreateImageSuccess && !openFile) // Наверное ошибочно
			if (CreateImageSuccess)
				moveTop = true;
			openFile = false; // Наверное не нужно
			cellValue = false;
		}

		void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			try
			{
				if (MoveTop)
				{
					if (!changeScale)
					{
						MyTable[RowForMoveTop, 0] = e.X * Length_Square_metre / Length_Square_pixel;
						MyTable[RowForMoveTop, 1] = e.Y * Length_Square_metre / Length_Square_pixel;
						MyTable[RowForMoveTop, 1] = Length_Square_metre - MyTable[RowForMoveTop, 1];
					}
					else
					{
						int deltaPosX = e.X - pos[RowForMoveTop].X;
						int deltaPosY = e.Y - pos[RowForMoveTop].Y;
						MyTable[RowForMoveTop, 0] = posNotScale[RowForMoveTop].X * Length_Square_metre / Length_Square_pixel + deltaPosX * (Length_Square_metre * 100 / myScale) / Length_Square_pixel;
						MyTable[RowForMoveTop, 1] = posNotScale[RowForMoveTop].Y * Length_Square_metre / Length_Square_pixel + deltaPosY * (Length_Square_metre * 100 / myScale) / Length_Square_pixel;
						MyTable[RowForMoveTop, 1] = Length_Square_metre - MyTable[RowForMoveTop, 1];
					}
					int RowTopPred, RowTopSled;
					if (RowForMoveTop == 0)
					{
						RowTopPred = MyTable.GetUpperBound(0);
						RowTopSled = 1;
					}
					else if (RowForMoveTop == MyTable.GetUpperBound(0))
					{
						RowTopPred = RowForMoveTop - 1;
						RowTopSled = 0;
					}
					else
					{
						RowTopPred = RowForMoveTop - 1;
						RowTopSled = RowForMoveTop + 1;
					}
					double a1, b1, c1, alfa1, a2, b2, c2, alfa2;
					a1 = Math.Abs(MyTable[RowForMoveTop, 0] - MyTable[RowTopPred, 0]);
					b1 = Math.Abs(MyTable[RowForMoveTop, 1] - MyTable[RowTopPred, 1]);
					c1 = Math.Sqrt(Math.Pow(a1, 2) + Math.Pow(b1, 2));
					a2 = Math.Abs(MyTable[RowTopSled, 0] - MyTable[RowForMoveTop, 0]);
					b2 = Math.Abs(MyTable[RowTopSled, 1] - MyTable[RowForMoveTop, 1]);
					c2 = Math.Sqrt(Math.Pow(a2, 2) + Math.Pow(b2, 2));

					if (MyTable[RowTopPred, 0] == MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] < MyTable[RowForMoveTop, 1])
					{
						if (RowTopPred != MyTable.GetUpperBound(0))
						{
							dataGridView1.Rows[RowTopPred].Cells[1].Value = 0;
							dataGridView1.Rows[RowTopPred].Cells[2].Value = Math.Round(b1, 2);
						}
					}
					if (MyTable[RowForMoveTop, 0] == MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] < MyTable[RowTopSled, 1])
					{
						if (RowForMoveTop != MyTable.GetUpperBound(0))
						{
							dataGridView1.Rows[RowForMoveTop].Cells[1].Value = 0;
							dataGridView1.Rows[RowForMoveTop].Cells[2].Value = Math.Round(b2, 2);
						}
					}

					if (MyTable[RowTopPred, 0] < MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] < MyTable[RowForMoveTop, 1])
					{
						alfa1 = Math.Acos(b1 / c1) * 180 / Math.PI;
						if (RowTopPred != MyTable.GetUpperBound(0))
						{
							dataGridView1.Rows[RowTopPred].Cells[1].Value = Math.Round(alfa1, 2);
							dataGridView1.Rows[RowTopPred].Cells[2].Value = Math.Round(c1, 2);
						}
					}
					if (MyTable[RowForMoveTop, 0] < MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] < MyTable[RowTopSled, 1])
					{
						alfa2 = Math.Acos(b2 / c2) * 180 / Math.PI;
						if (RowForMoveTop != MyTable.GetUpperBound(0))
						{
							dataGridView1.Rows[RowForMoveTop].Cells[1].Value = Math.Round(alfa2, 2);
							dataGridView1.Rows[RowForMoveTop].Cells[2].Value = Math.Round(c2, 2);
						}
					}

					if (MyTable[RowTopPred, 0] < MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] == MyTable[RowForMoveTop, 1])
					{
						if (RowTopPred != MyTable.GetUpperBound(0))
						{
							dataGridView1.Rows[RowTopPred].Cells[1].Value = 90;
							dataGridView1.Rows[RowTopPred].Cells[2].Value = Math.Round(a1, 2);
						}
					}
					if (MyTable[RowForMoveTop, 0] < MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] == MyTable[RowTopSled, 1])
					{
						if (RowForMoveTop != MyTable.GetUpperBound(0))
						{
							dataGridView1.Rows[RowForMoveTop].Cells[1].Value = 90;
							dataGridView1.Rows[RowForMoveTop].Cells[2].Value = Math.Round(a2, 2);
						}
					}

					if (MyTable[RowTopPred, 0] < MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] > MyTable[RowForMoveTop, 1])
					{
						alfa1 = Math.Acos(a1 / c1) * 180 / Math.PI;
						if (RowTopPred != MyTable.GetUpperBound(0))
						{
							dataGridView1.Rows[RowTopPred].Cells[1].Value = Math.Round(alfa1, 2) + 90;
							dataGridView1.Rows[RowTopPred].Cells[2].Value = Math.Round(c1, 2);
						}
					}
					if (MyTable[RowForMoveTop, 0] < MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] > MyTable[RowTopSled, 1])
					{
						alfa2 = Math.Acos(a2 / c2) * 180 / Math.PI;
						if (RowForMoveTop != MyTable.GetUpperBound(0))
						{
							dataGridView1.Rows[RowForMoveTop].Cells[1].Value = Math.Round(alfa2, 2) + 90;
							dataGridView1.Rows[RowForMoveTop].Cells[2].Value = Math.Round(c2, 2);
						}
					}

					if (MyTable[RowTopPred, 0] == MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] > MyTable[RowForMoveTop, 1])
					{
						if (RowTopPred != MyTable.GetUpperBound(0))
						{
							dataGridView1.Rows[RowTopPred].Cells[1].Value = 180;
							dataGridView1.Rows[RowTopPred].Cells[2].Value = Math.Round(b1, 2);
						}
					}
					if (MyTable[RowForMoveTop, 0] == MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] > MyTable[RowTopSled, 1])
					{
						if (RowForMoveTop != MyTable.GetUpperBound(0))
						{
							dataGridView1.Rows[RowForMoveTop].Cells[1].Value = 180;
							dataGridView1.Rows[RowForMoveTop].Cells[2].Value = Math.Round(b2, 2);
						}
					}

					if (MyTable[RowTopPred, 0] > MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] > MyTable[RowForMoveTop, 1])
					{
						alfa1 = Math.Acos(b1 / c1) * 180 / Math.PI;
						if (RowTopPred != MyTable.GetUpperBound(0))
						{
							dataGridView1.Rows[RowTopPred].Cells[1].Value = Math.Round(alfa1, 2) + 180;
							dataGridView1.Rows[RowTopPred].Cells[2].Value = Math.Round(c1, 2);
						}
					}
					if (MyTable[RowForMoveTop, 0] > MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] > MyTable[RowTopSled, 1])
					{
						alfa2 = Math.Acos(b2 / c2) * 180 / Math.PI;
						if (RowForMoveTop != MyTable.GetUpperBound(0))
						{
							dataGridView1.Rows[RowForMoveTop].Cells[1].Value = Math.Round(alfa2, 2) + 180;
							dataGridView1.Rows[RowForMoveTop].Cells[2].Value = Math.Round(c2, 2);
						}
					}

					if (MyTable[RowTopPred, 0] > MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] == MyTable[RowForMoveTop, 1])
					{
						if (RowTopPred != MyTable.GetUpperBound(0))
						{
							dataGridView1.Rows[RowTopPred].Cells[1].Value = 270;
							dataGridView1.Rows[RowTopPred].Cells[2].Value = Math.Round(a1, 2);
						}
					}
					if (MyTable[RowForMoveTop, 0] > MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] == MyTable[RowTopSled, 1])
					{
						if (RowForMoveTop != MyTable.GetUpperBound(0))
						{
							dataGridView1.Rows[RowForMoveTop].Cells[1].Value = 270;
							dataGridView1.Rows[RowForMoveTop].Cells[2].Value = Math.Round(a2, 2);
						}
					}

					if (MyTable[RowTopPred, 0] > MyTable[RowForMoveTop, 0] && MyTable[RowTopPred, 1] < MyTable[RowForMoveTop, 1])
					{
						alfa1 = Math.Acos(a1 / c1) * 180 / Math.PI;
						if (RowTopPred != MyTable.GetUpperBound(0))
						{
							dataGridView1.Rows[RowTopPred].Cells[1].Value = Math.Round(alfa1, 2) + 270;
							dataGridView1.Rows[RowTopPred].Cells[2].Value = Math.Round(c1, 2);
						}
					}
					if (MyTable[RowForMoveTop, 0] > MyTable[RowTopSled, 0] && MyTable[RowForMoveTop, 1] < MyTable[RowTopSled, 1])
					{
						alfa2 = Math.Acos(a2 / c2) * 180 / Math.PI;
						if (RowForMoveTop != MyTable.GetUpperBound(0))
						{
							dataGridView1.Rows[RowForMoveTop].Cells[1].Value = Math.Round(alfa2, 2) + 270;
							dataGridView1.Rows[RowForMoveTop].Cells[2].Value = Math.Round(c2, 2);
						}
					}
					CreatePlan();
					Square();
					Perimetr();
				}
				else if (ListPoint.Count > 0)
				{
					pictureBox1.Refresh();
					if (ListPoint.Count == 2)
						graphLines.DrawLine(penLines, ListPoint[0].X, ListPoint[0].Y, ListPoint[1].X, ListPoint[1].Y);
					else if (ListPoint.Count > 2)
						for (int i = 0; i < ListPoint.Count - 1; i++)
							graphLines.DrawLine(penLines, ListPoint[i].X, ListPoint[i].Y, ListPoint[i + 1].X, ListPoint[i + 1].Y);
					graphLines.DrawLine(penLines, ListPoint[ListPoint.Count - 1].X, ListPoint[ListPoint.Count - 1].Y, e.X, e.Y);
					double LS = (Length_Square_metre * 100 / myScale) * Math.Sqrt(Math.Pow(e.X - ListPoint[ListPoint.Count - 1].X, 2) + Math.Pow(e.Y - ListPoint[ListPoint.Count - 1].Y, 2)) / Length_Square_pixel;
					labelLengthSegment.Text = (Math.Round((float)LS, 2)).ToString();
					if (ListPoint.Count == 1)
						labelLengthAll.Text = labelLengthSegment.Text;
					else if (ListPoint.Count == 2)
						labelLengthAll.Text = (Math.Round((float)((Length_Square_metre * 100 / myScale) * Math.Sqrt(Math.Pow(ListPoint[1].X - ListPoint[0].X, 2) + Math.Pow(ListPoint[1].Y - ListPoint[0].Y, 2)) / Length_Square_pixel + LS), 2)).ToString();
					else
					{
						double L = 0;
						for (int i = 0; i < ListPoint.Count - 1; i++)
							L += (Length_Square_metre * 100 / myScale) * Math.Sqrt(Math.Pow(ListPoint[i + 1].X - ListPoint[i].X, 2) + Math.Pow(ListPoint[i + 1].Y - ListPoint[i].Y, 2)) / Length_Square_pixel;
						labelLengthAll.Text = (Math.Round((float)(L + LS), 2)).ToString();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n\nРЕКОМЕНДУЕТСЯ СОХРАНИТЬ ВСЕ ДАННЫЕ И ПЕРЕЗАГРУЗИТЬ ПРОГРАММУ!", "Ошибка программы", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			ClearLines();
		}

		void ClearLines()
		{
			pictureBox1.Refresh();
			ListPoint.Clear();
			labelLengthSegment.Text = "0";
		}

		private void открытьФайлToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			openFile = true; // Наверное не нужно
			ClearLines();
			labelLengthAll.Text = "0";
			labelLengthSegment.Text = "0";
			if (openFileDialog1.ShowDialog(this) == DialogResult.OK && openFileDialog1.FileName.Length > 0)
			{
				try
				{					
					buttonClearClick(); tableClear = false;
					StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.Unicode, true);
					string str0, str1, str2;
					while (true)
					{
						str0 = sr.ReadLine();
						if (str0 == null)
							break;
						if (str0[0] == 'Д')
						{
							textSquare.Text = str0.Substring(str0.LastIndexOf("=") + 2);
							textSquareKeyPress();
							textSquareKeyPressBOOL = false;
						}
						if (str0[0] != 'А' && str0[0] != 'Д')
						{
							DataRow newRow = myDataTable.NewRow();
							str1 = str0.Substring(0, str0.IndexOf("\t"));
							newRow[1] = Convert.ToSingle(str1);
							str2 = str0.Substring(str0.IndexOf("\t") + 1);
							newRow[2] = Convert.ToSingle(str2);
							myDataTable.Rows.Add(newRow);
						}
					}
					sr.Close();
					for (int i = 0; i < myDataTable.Rows.Count; i++)
						if (myDataTable.Rows[i][1].ToString() == "" && myDataTable.Rows[i][2].ToString() == "")
							myDataTable.Rows[i].Delete();
					buttonLeft.Enabled = true;
					buttonRight.Enabled = true;
					textTurn.Enabled = true;
					textTurn.Text = "0";
					myTurn = 0;
					chTurn = false;
					changeTurn = false;
					butScaleMin.Enabled = true;
					butScaleMax.Enabled = true;
					textScale.Enabled = true;
					textScale.Text = "100";
					myScale = 100;
					changeScale = false;
					myDataTable.AcceptChanges();
					dataGridView1.Refresh();
					CreatePlan();
					DrawPanel();
					if (CreateMyTableSuccess || changeTurn || MoveTop)
					{
						Square();
						Perimetr();
					}
					else
					{
						labelSquare2.Text = "0";
						labelPerimetr2.Text = "0";
					}
					this.Text = "Файл \"" + openFileDialog1.FileName + "\"";
				}
				catch (Exception ex)
				{
					result = MessageBox.Show(ex.Message, "Системная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				MoveTop = false;
				moveTop = false;
				res = false;
			}
		}

		private void сохранитьФайлToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			ClearLines();
			labelLengthAll.Text = "0";
			labelLengthSegment.Text = "0";
			if (saveFileDialog1.ShowDialog(this) == DialogResult.OK && saveFileDialog1.FileName.Length > 0)
			{
				try
				{
					for (int i = 0; i < myDataTable.Rows.Count; i++)
						if (myDataTable.Rows[i][1].ToString() == "" && myDataTable.Rows[i][2].ToString() == "")
							myDataTable.Rows[i].Delete();
					StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.Unicode);
					sw.WriteLine("Длина стороны внешнего квадрата, м = " + Length_Square_metre.ToString());
					sw.WriteLine("Азимут\tДлина");
					for (int i = 0; i < myDataTable.Rows.Count; ++i)
						sw.WriteLine(myDataTable.Rows[i][1] + "\t" + myDataTable.Rows[i][2]);
					sw.Flush();
					sw.Close();
					this.Text = "Файл \"" + saveFileDialog1.FileName + "\"";
				}
				catch (Exception ex)
				{
					result = MessageBox.Show(ex.Message, "Системная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				MoveTop = false;
				moveTop = false;
			}
		}

		private void infoToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			MoveTop = false;
			moveTop = false;
			ClearLines();
			labelLengthAll.Text = "0";
			labelLengthSegment.Text = "0";
			FormHelp formHelp = new FormHelp();
			formHelp.Show();
		}

		private void aboutToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			MoveTop = false;
			moveTop = false;
			ClearLines();
			labelLengthAll.Text = "0";
			labelLengthSegment.Text = "0";
			FormAbout formAbout = new FormAbout();
			formAbout.ShowDialog();
		}
	}
}
