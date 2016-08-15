using System.Collections.Generic;
using Newtonsoft.Json;




namespace Nez.PipelineImporter.Spriter
{
  public class SpriterFile
  {
    [JsonProperty("frames")]
    public List<TexturePackerRegion> regions;

    [JsonProperty("meta")]
    public TexturePackerMeta metadata;
  }
}