using NUnit.Framework;
using CSharp_PVRTC_EncDec;

namespace tests
{
	public class RoundTripTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void EncodeOneBlockPureWhiteRGBAndDecodeIt()
		{
			// Arrange
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

			TempByteImageFormat decoded = PvrtcDecompress.DecodeRgb4Bpp(encodedBytes, 4);
			byte[] firstPixel = decoded.GetPixelChannels(0, 0);

			// Assert
			Assert.AreEqual(8, encodedBytes.Length);
			
			Assert.AreEqual(width, decoded.GetWidth());
			Assert.AreEqual(height, decoded.GetHeight());
			Assert.AreEqual(channelsPerPixel, decoded.GetChannelsPerPixel());
			CollectionAssert.AreEqual(whiteRGB, firstPixel);
		}
	}
}