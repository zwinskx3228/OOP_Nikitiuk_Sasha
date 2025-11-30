// ClassLibrary8/Interfaces/Room.Partial.cs
using System.Diagnostics;

namespace ClassLibrary8.Interfaces
{
	public partial class Room
	{
		partial void OnPriceChanged()
		{
			Debug.WriteLine($"[ClassLibrary8] Room price changed to: {price}");
		}
	}
}