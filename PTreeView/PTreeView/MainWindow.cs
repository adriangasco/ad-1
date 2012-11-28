using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		//treeView.Selection.Mode = SelectionMode.Multiple;
		
		treeView.AppendColumn("Columna uno", new CellRendererText (), "text", 0);
		treeView.AppendColumn("Columna dos", new CellRendererText (), "text", 1);		
		
		ListStore listStore = new ListStore(typeof(string), typeof(string));
		
		treeView.Model = listStore;
		
		listStore.AppendValues ("clave uno", "valor uno");
		listStore.AppendValues ("clave dos", "valor dos");
		listStore.AppendValues ("clave tres", "valor tres");
		listStore.AppendValues ("clave cuatro", "valor cuatro");
		
		treeView.Selection.Changed += delegate {
			int count = treeView.Selection.CountSelectedRows ();
			Console.WriteLine ("treeView.Selection.Changed CountSelectedRows={0}", count);
			
			treeView.Selection.SelectedForeach(delegate(TreeModel model, TreePath path, TreeIter iter) {
				object value = listStore.GetValue(iter, 0);
				Console.WriteLine ("value={0}", value);
			});
		};
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
