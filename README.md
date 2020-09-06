# CSharp-PVRTC-EncDec

C# managed **PVRTC encoder/decoder library**. This is a C# implementation of [PVRTC texture format](http://en.wikipedia.org/wiki/PVRTC) compression and decompression. Only 4 bit modes supported.

## Build status
![](https://github.com/mcraiha/CSharp-PVRTC-encdec/workflows/.NET%20Core/badge.svg)

### Why?

Because I needed this for my personal project.

### What I could do with this

You can do runtime PVRTC compression in your app/software. This could be handy if you are doing procedural texture generation and want to save some GPU texture memory. Or you could in certain situation save few download bytes by sending e.g. PNG textures to device and then converting those to PVRTC.

### How to use


important functions are 
**EncodeRgb4Bpp(Texture2D bitmap)**

**EncodeRgba4Bpp(Texture2D bitmap)** 
and
**DecodeRgb4Bpp(byte[] data, int width)**

**DecodeRgba4Bpp(byte[] data, int width)**

### What could be better

* Performance could be better
* There could be a multithreaded version of encoder/decoder

### What it DOES NOT DO

* It does NOT support PVRTC 2 bit
* It does NOT open PVR files
* It does NOT generate PVR files

### License

This C# version is under [BSD License](LICENSE). That is because original C++ version is under [BSD License](https://bitbucket.org/jthlim/pvrtccompressor/src/cf7177748ee0dcdccfe89716dc11a47d2dc81af5/LICENSE.TXT?at=default&fileviewer=file-view-default).

### Thanks

**jthlim** and **Brendan Duncan** who made the [C++ implementation](https://bitbucket.org/jthlim/pvrtccompressor) that I shamelessly ported to C#.