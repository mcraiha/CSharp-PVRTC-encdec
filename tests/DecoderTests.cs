using NUnit.Framework;
using System.IO;
using CSharp_PVRTC_EncDec;

namespace tests
{
	public class DecoderTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void DecodeFile()
		{
			// Arrange
			FileStream pvrStream = new FileStream("hotair.4bpp.pvr", FileMode.Open, FileAccess.Read);
			byte[] array = new byte[512 * 512 / 2];

			// Act
			pvrStream.Seek(0x44, SeekOrigin.Begin);
			pvrStream.Read(array, 0, array.Length);
			TempByteImageFormat temp = PvrtcDecompress.DecodeRgb4Bpp(array, 512);

			// Assert
		}
	}
}