using System;
using System.Collections;
using System.Collections.Generic;
using Gtk;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Forms.PropertyGridInternal;

namespace LOL
{
	class MainClass
	{
		public static Label myLabel = new Label();
		public static DataTable dt = new DataTable ();
		public static TreeView bv = new TreeView ();
		public static MainWindow win;
		public static ListStore musicListStore;
		public static MenuBar mb;

		public static void Main (string[] args)
		{
			Application.Init ();
			win = new MainWindow ();
			VBox vbox1 = new VBox (false, 6);
			vbox1.BorderWidth = 0;
			win.Show ();
			myLabel.Text = "Hello World!!!!";
			//win.Add(myLabel);
			mb = new MenuBar ();
			mb.PackDirection = PackDirection.Ltr;
			mb.ChildPackDirection = PackDirection.Ltr;
			Menu file_menu = new Menu ();
			MenuItem exit_item = new MenuItem ("Exit");
			exit_item.Activated += new EventHandler (on_exit_item_activate);
			file_menu.Append (exit_item);
			MenuItem file_item = new MenuItem("База данных");
			file_item.Submenu = file_menu;
			mb.Append (file_item);
			win.Add (vbox1);
			win.Add (bv);
			musicListStore = new ListStore (typeof(string), typeof(string));
			bv.Model = musicListStore;
			MainClass.AddButton (vbox1);
			MainClass.AddButton1 (vbox1);

			win.ShowAll();
			conncet ();
			Application.Run ();
		}
		static void AddButton (VBox box)
		{
			box.PackStart (mb, false, true, 0);
		}
		static void AddButton1 (VBox box)
		{
			box.PackStart (bv);
		}	

		static void on_exit_item_activate (object sender, EventArgs e)
		{
			Application.Quit ();
		}

		static async Task createColumns(SqlConnection con)
		{
			SqlCommand cmd = new SqlCommand("SELECT name FROM sys.columns WHERE object_id = OBJECT_ID('dbo.Tovar')", con);
			SqlDataReader dr = cmd.ExecuteReader();
			if(dr.HasRows) // если есть данные
			{
				int i = 0;
				while (dr.Read()) // построчно считываем данные
				{
					object title = dr.GetValue(0);
					TreeViewColumn newColumn = new TreeViewColumn ();
					newColumn.Title = title.ToString();	
					CellRendererText newColumnCell = new CellRendererText ();
					newColumn.PackStart (newColumnCell, true);
					bv.AppendColumn (newColumn);
					newColumn.AddAttribute (newColumnCell, "text", i);
					i++;
				}
				// Assign the model to the TreeView
				bv.Model = musicListStore;

				win.ShowAll ();
			}

			dr.Close();


		}

		static async Task conncet()
		{
			string connectionString = "Server=127.0.0.1,1433; Database=master;User ID=SA;Password=<YourStrong@Passw0rd>;";

			// Создание подключения
			SqlConnection connection = new SqlConnection(connectionString);
			try
			{
				// Открываем подключение
				await connection.OpenAsync();
				myLabel.Text = "Подключились";
				await createColumns(connection);
				myLabel.Text += "Connection";

				SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Tovar]", connection);
				SqlDataReader dr = cmd.ExecuteReader();

				myLabel.Text += "show myst start";

				if(dr.HasRows) // если есть данные
				{
					while (dr.Read()) // построчно считываем данные
					{
						object id = dr.GetValue(0);
						object name = dr.GetValue(1);
						object age = dr.GetValue(2);
						myLabel.Text +=$"{id} \t{name} \t{age}";
						musicListStore.AppendValues (id, name);
						bv.Model = musicListStore;
						win.ShowAll();
					}
				}

				dr.Close();

			}
			catch (SqlException ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				// если подключение открыто
				//if (connection.State != ConnectionState.Closed)
					//await connection.CloseAsync();
			}
		//	myLabel.Text = ("Программа завершила работу.a");
		//	win.ShowAll ();
			//return  0;
		}


	}
}
