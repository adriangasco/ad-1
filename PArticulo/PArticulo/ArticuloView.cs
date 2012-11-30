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
			set {entryNombre.Text = value;} 
		}
		
		public double Precio {
			set {spinButtonPrecio.Value = value;}
		}
		
		public long Categoria {
			set {
				//TODO implementar...
			}
		}
				
		
	}
}

