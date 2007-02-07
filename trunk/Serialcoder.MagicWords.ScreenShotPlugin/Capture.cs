#region Using
using System;
using System.Runtime.InteropServices;
using System.Drawing;
#endregion

namespace Serialcoder.MagicWords.ScreenShotPlugin
{
	/// <summary>
	/// Helper class to do a screenshot of a specified window handle
	/// </summary>
	public class Capture
	{
		#region Invoke APIs
		[StructLayout(LayoutKind.Sequential)]
		private struct RECT
		{
			public int Left;
			public int Top;
			public int Right;
			public int Bottom;
		}
		[DllImport("GDI32")]
		private static extern int DeleteDC(IntPtr hdc);
		[DllImport("user32")]
		private static extern long ReleaseDC(IntPtr hwnd, IntPtr hdc);
		[DllImport("gdi32")]
		private static extern int DeleteObject(IntPtr hObj);
		[DllImport("gdi32")]
		private static extern int CreateCompatibleDC(IntPtr hDC);
		[DllImport("user32")]
		private static extern int GetWindowDC(IntPtr hwnd);
		[DllImport("gdi32")]
		private static extern int SelectObject(IntPtr hDC, IntPtr hObject);
		[DllImport("gdi32")]
		private static extern int CreateCompatibleBitmap(IntPtr hDC, IntPtr nWidth, IntPtr nHeight);
		[DllImport("user32")]
		private static extern System.Int32 GetWindowRect(IntPtr hwnd, ref RECT lpRect);
		[DllImport("user32")]
		private static extern bool IsWindow(IntPtr hwnd);
		[DllImport("gdi32.dll")]
		private static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int
		nXSrc, int nYSrc, System.Int32 dwRop);
		#endregion

		#region Create Bitmap
		public static Bitmap GrabWindow(IntPtr hWnd)
		{
			try
			{
				long hWindowDC, hOffscreenDC, nWidth, nHeight, hBitmap, hOldBmp;
				RECT rec;
				rec = new RECT();
				Bitmap MyBitmap;
				MyBitmap = new Bitmap(640, 480);
				if ((hWnd.ToInt32() != 0) && (IsWindow(hWnd)))
				{
					hWindowDC = GetWindowDC(hWnd);
					if (hWindowDC.ToString() != null)
					{
						if (GetWindowRect(hWnd, ref rec).ToString() != null)
						{
							nWidth = rec.Right - rec.Left;
							nHeight = rec.Bottom - rec.Top;
							hOffscreenDC = CreateCompatibleDC(new System.IntPtr(hWindowDC));
							if (hOffscreenDC.ToString() != null)
							{
								hBitmap = CreateCompatibleBitmap(new System.IntPtr(hWindowDC), new System.IntPtr(nWidth), new System.IntPtr(nHeight));
								if (hBitmap.ToString() != null)
								{
									hOldBmp = SelectObject(new System.IntPtr(hOffscreenDC), new System.IntPtr(hBitmap));
									BitBlt(new System.IntPtr(hOffscreenDC), 0, 0, (int)nWidth, (int)nHeight, new System.IntPtr(hWindowDC), 0, 0, 13369376);
									MyBitmap = Bitmap.FromHbitmap(new IntPtr(hBitmap));
									DeleteObject(new System.IntPtr((SelectObject(new System.IntPtr(hOffscreenDC), new System.IntPtr(hOldBmp)))));
								}
								DeleteDC(new System.IntPtr(hOffscreenDC));
							}
						}
						ReleaseDC(hWnd, new System.IntPtr(hWindowDC));
						GC.Collect();
					}
				}
				return MyBitmap;
			}
			catch (Exception ex)
			{
				System.Console.WriteLine(ex.Message);
				return null;
			}
		}
		#endregion
	}
}
