using System.Collections.Generic;

namespace Chess {
    public class ChessPawn : Piece {
        
        private bool _hasMoved;
        
        public ChessPawn(Coordinate currentCoordinate, PlayerColor player) : base(currentCoordinate, player) { }

        public override int Value => 1;

        public override List<Coordinate> AvailableMoves(Board board) {
            List<Coordinate> availableMoves = new List<Coordinate>();
            if (Player == PlayerColor.White) {
                if (!_hasMoved && board.ValidCoordinate(CurrentCoordinate.ToTopJump) && !board.OccupiedCoordinate(CurrentCoordinate.ToTopJump) && 
                    !board.OccupiedCoordinate(CurrentCoordinate.ToTop)) 
                    availableMoves.Add(CurrentCoordinate.ToTopJump);
                if (board.ValidCoordinate(CurrentCoordinate.ToTop) && !board.OccupiedCoordinate(CurrentCoordinate.ToTop)) 
                    availableMoves.Add(CurrentCoordinate.ToTop);
                if (board.ValidCoordinate(CurrentCoordinate.ToTopRight) && board.OccupiedCoordinate(CurrentCoordinate.ToTopRight, OtherPlayer)) 
                    availableMoves.Add(CurrentCoordinate.ToTopRight);
                if (board.ValidCoordinate(CurrentCoordinate.ToTopLeft) && board.OccupiedCoordinate(CurrentCoordinate.ToTopLeft, OtherPlayer)) 
                    availableMoves.Add(CurrentCoordinate.ToTopLeft);
            }
            if (Player == PlayerColor.Black) {
                if (!_hasMoved && board.ValidCoordinate(CurrentCoordinate.ToBottomJump) && !board.OccupiedCoordinate(CurrentCoordinate.ToBottomJump) &&
                    !board.OccupiedCoordinate(CurrentCoordinate.ToBottom)) 
                    availableMoves.Add(CurrentCoordinate.ToBottomJump);
                if (board.ValidCoordinate(CurrentCoordinate.ToBottom) && !board.OccupiedCoordinate(CurrentCoordinate.ToBottom))
                    availableMoves.Add(CurrentCoordinate.ToBottom);
                if (board.ValidCoordinate(CurrentCoordinate.ToBottomRight) && board.OccupiedCoordinate(CurrentCoordinate.ToBottomRight, OtherPlayer))
                    availableMoves.Add(CurrentCoordinate.ToBottomRight);
                if (board.ValidCoordinate(CurrentCoordinate.ToBottomLeft) && board.OccupiedCoordinate(CurrentCoordinate.ToBottomLeft, OtherPlayer))
                    availableMoves.Add(CurrentCoordinate.ToBottomLeft);
            }
            return availableMoves;
        }

        public override void ExecuteMove(Board board, Coordinate destination) {
            _hasMoved = true;
            // Move to position
            board.Matrix[destination.Row, destination.Column] = board.Matrix[CurrentCoordinate.Row, CurrentCoordinate.Column];
            board.Matrix[CurrentCoordinate.Row, CurrentCoordinate.Column] = null;
            CurrentCoordinate = destination;
        }

        public override object Clone() {
            return new ChessPawn(CurrentCoordinate, Player);
        }

    }
}