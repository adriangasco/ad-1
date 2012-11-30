using Gtk;
using Npgsql;
using Serpis.Ad;
using System;
using System.Collections.Generic;
using System.Data;

using PArticulo;

public partial class MainWindow: Gtk.Window
{	
	private IDbConnection dbConnection;
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		string connectionString = "Server=localhost;Database=dbprueba;User Id=dbprueba;Password=sistemas";
		dbConnection = new NpgsqlConnection(connectionString);
		dbConnection.Open ();
		
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = 
			"select a.id, a.nombre, a.precio, c.nombre as categoria " +
			"from articulo a left join categoria c " +
			"on a.categoria = c.id";
		
		IDataReader dataReader = dbCommand.ExecuteReader ();
		
		TreeViewExtensions.Fill (treeView, dataReader);
		dataReader.Close ();
		
		dataReader = dbCommand.ExecuteReader ();
		TreeViewExtensions.Fill (treeView, dataReader);
		dataReader.Close ();
		
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		dbConnection.Close ();

		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnClearActionActivated (object sender, System.EventArgs e)
	{
		ListStore listStore = (ListStore)treeView.Model;
		listStore.Clear ();
	}

	protected void OnEditActionActivated (object sender, System.EventArgs e)
	{
		long id = getSelectedId();
		
		Console.WriteLine ("id={0}", id);
		
		IDbCommand dbCommand = dbConnection.CreateCommand();
		//dbCommand.CommandText = "select * from articulo where id="+id;
		dbCommand.CommandText = string.Format ("select * from articulo where id={0}", id);
//		dbCommand.CommandText = "select * from articulo where id=:id";
//		IDbDataParameter dbDataParameter = dbCommand.CreateParameter();
//		dbCommand.Parameters.Add (dbDataParameter);
//		dbDataParameter.ParameterName = "id";
//		dbDataParameter.Value = id;
		
		IDataReader dataReader = dbCommand.ExecuteReader ();
		dataReader.Read ();
		
		
		ArticuloView articuloView = new ArticuloView();
		articuloView.Nombre = (string)dataReader["nombre"];
		articuloView.Precio = double.Parse (dataReader["precio"].ToString ());
		
		articuloView.Show ();
		
		dataReader.Close ();
		
	}
	
	private long getSelectedId() {
		TreeIter treeIter;
		treeView.Selection.GetSelected(out treeIter);
		
		ListStore listStore = (ListStore)treeView.Model;
		return long.Parse (listStore.GetValue (treeIter, 0).ToString ()); 
	}
}
