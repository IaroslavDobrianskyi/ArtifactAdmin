namespace ArtifactAdmin.BL.Interfaces
{
    using Utils.MapHelpers;

    public interface IMapManagerService
    {
        MapManager GetFirstMapManager();
        MapManager GetMapManager(int mapInfoId);
    }
}