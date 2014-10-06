using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace Skyiv.Ben.Common
{
  static class Zip
  {
    public static ZipInputStream GetZipInputStream(Stream zipStream, string fileName)
    {
      ZipInputStream zs = new ZipInputStream(zipStream);
      ZipEntry theEntry;
      while ((theEntry = zs.GetNextEntry()) != null)
      {
        if (theEntry.Name != fileName) continue;
        return zs;
      }
      throw new FileNotFoundException("压缩包中无此文件: " + fileName);
    }
  }
}
