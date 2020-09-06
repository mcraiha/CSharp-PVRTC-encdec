using NUnit.Framework;
using CSharp_PVRTC_EncDec;

namespace tests
{
	public class EncoderTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void EncodeRBGWhiteBlock()
		{
			// Arrange
			byte[] expected = new byte[8] { 0, 0, 0, 0, 254, 255, 255, 255 };

			const int width = 4; // One block is 4x4
			const int height = 4;
			const int channelsPerPixel = 3;
			byte[] whiteRGB = new byte[] { 255, 255, 255 };
			byte[,,] pixels = new byte[width, height, channelsPerPixel] {
				{ { 255, 255, 255 }, { 255, 255, 255 }, { 255, 255, 255 }, { 255, 255, 255 }},
				{ { 255, 255, 255 }, { 255, 255, 255 }, { 255, 255, 255 }, { 255, 255, 255 }},
				{ { 255, 255, 255 }, { 255, 255, 255 }, { 255, 255, 255 }, { 255, 255, 255 }},
				{ { 255, 255, 255 }, { 255, 255, 255 }, { 255, 255, 255 }, { 255, 255, 255 }},
			};
			TempByteImageFormat image = new TempByteImageFormat(pixels);

			// Act
			byte[] encodedBytes = PvrtcCompress.EncodeRgb4Bpp(image);

			// Assert
			Assert.AreEqual(8, encodedBytes.Length);
			CollectionAssert.AreEqual(expected, encodedBytes);
		}
	}
}