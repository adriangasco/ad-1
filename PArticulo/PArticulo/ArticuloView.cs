using Gtk;
using System;

namespace PArticulo
{
	public partial class ArticuloView : Gtk.Window
	{
		public ArticuloView () : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
		
		public string Nombre { 
			get {return entryNombre.Text;}
			set {entryNombre.Text = value;} 
		}
		
		public decimal Precio {
			get {return Convert.ToDecimal (spinButtonPrecio.Value);}
			set {spinButtonPrecio.Value = Convert.ToDouble(value);}
		}
		
		public long Categoria {
			set {
				//TODO implementar...
			}
		}
		
		public Gtk.Action SaveAction {
			get {return saveAction;}
		}
	}
}

