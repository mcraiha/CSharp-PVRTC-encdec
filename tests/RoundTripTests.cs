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
		public void EncodeOneBlockPureWhiteRGBThenDecodeIt()
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

			TempByteImageFormat decoded = PvrtcDecompress.DecodeRgb4Bpp(encodedBytes, width);
			byte[] firstPixel = decoded.GetPixelChannels(0, 0);

			// Assert
			Assert.AreEqual(8, encodedBytes.Length);
			
			Assert.AreEqual(width, decoded.GetWidth());
			Assert.AreEqual(height, decoded.GetHeight());
			Assert.AreEqual(channelsPerPixel, decoded.GetChannelsPerPixel());
			CollectionAssert.AreEqual(whiteRGB, firstPixel);
		}

		[Test]
		public void EncodeOneBlockPureWhiteRGBAThenDecodeIt()
		{
			// Arrange
			const int width = 4; // One block is 4x4
			const int height = 4;
			const int channelsPerPixel = 4;
			byte[] whiteRGB = new byte[] { 255, 255, 255, 255 };
			byte[,,] pixels = new byte[width, height, channelsPerPixel] {
				{ { 255, 255, 255, 255 }, { 255, 255, 255, 255 }, { 255, 255, 255, 255 }, { 255, 255, 255, 255 }},
				{ { 255, 255, 255, 255 }, { 255, 255, 255, 255 }, { 255, 255, 255, 255 }, { 255, 255, 255, 255 }},
				{ { 255, 255, 255, 255 }, { 255, 255, 255, 255 }, { 255, 255, 255, 255 }, { 255, 255, 255, 255 }},
				{ { 255, 255, 255, 255 }, { 255, 255, 255, 255 }, { 255, 255, 255, 255 }, { 255, 255, 255, 255 }},
			};
			TempByteImageFormat image = new TempByteImageFormat(pixels);

			// Act
			byte[] encodedBytes = PvrtcCompress.EncodeRgba4Bpp(image);

			TempByteImageFormat decoded = PvrtcDecompress.DecodeRgba4Bpp(encodedBytes, width);
			byte[] firstPixel = decoded.GetPixelChannels(0, 0);

			// Assert
			Assert.AreEqual(8, encodedBytes.Length);
			
			Assert.AreEqual(width, decoded.GetWidth());
			Assert.AreEqual(height, decoded.GetHeight());
			Assert.AreEqual(channelsPerPixel, decoded.GetChannelsPerPixel());
			CollectionAssert.AreEqual(whiteRGB, firstPixel);
		}

		[Test]
		public void EncodeFourBlocksPureBlackRGBThenDecodeIt()
		{
			// Arrange
			const int width = 8; // One block is 4x4, so 8x8 is 4 blocks
			const int height = 8;
			const int channelsPerPixel = 3;
			byte[] blackRGB = new byte[] { 0, 0, 0 };
			byte[,,] pixels = new byte[width, height, channelsPerPixel] {
				{ { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
				{ { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
				{ { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
				{ { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
				{ { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
				{ { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
				{ { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
				{ { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
			};
			TempByteImageFormat image = new TempByteImageFormat(pixels);

			// Act
			byte[] encodedBytes = PvrtcCompress.EncodeRgb4Bpp(image);

			TempByteImageFormat decoded = PvrtcDecompress.DecodeRgb4Bpp(encodedBytes, width);
			byte[] firstPixel = decoded.GetPixelChannels(0, 0);

			// Assert
			Assert.AreEqual(32, encodedBytes.Length);
			
			Assert.AreEqual(width, decoded.GetWidth());
			Assert.AreEqual(height, decoded.GetHeight());
			Assert.AreEqual(channelsPerPixel, decoded.GetChannelsPerPixel());
			CollectionAssert.AreEqual(blackRGB, firstPixel);
		}
	}
}