using System;
using System.Collections.Generic;


namespace Serpis.Ad
{
	public static class TypeExtensions
	{
		/// <summary>
		/// Devuelve el array conteniendo el tipo indicado (type) las veces indicadas (count).
		/// </summary>
		public static Type[] GetTypes(Type type, int count)
		{
			List<Type> types = new List<Type>();
			for (int index = 0; index < count; index++)
				types.Add(type);
			return types.ToArray ();
		}
		
	}
}

