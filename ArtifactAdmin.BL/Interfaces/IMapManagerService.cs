namespace ArtifactAdmin.BL.Interfaces
{
    using MapHelpers;

    public interface IMapManagerService
    {
        MapManager GetFirstMapManager();
        MapManager GetMapManager(int mapInfoId);
    }
}