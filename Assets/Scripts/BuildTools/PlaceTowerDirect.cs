using System;

namespace BuildTools
{
    [Serializable]
    public class PlaceTowerDirect : BuildTool
    {
        public override bool CanSelect()
        {
            throw new NotImplementedException();
        }

        public override bool UseTool(Tile target)
        {
            throw new NotImplementedException();
        }

        public override void OnDeselect()
        {
            throw new NotImplementedException();
        }

        public override void OnSelect()
        {
            throw new NotImplementedException();
        }

        public override void Charge(Tile tile)
        {
            throw new NotImplementedException();
        }
    }
}