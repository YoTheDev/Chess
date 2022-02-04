using System.Collections.Generic;

namespace Checkers {
    public class CheckersKing : Piece {
        
        public CheckersKing(Coordinate currentCoordinate, PlayerColor player) : base(currentCoordinate, player) { }
        
        public override int Value => 5;

        public override List<Coordinate> AvailableMoves(Board board) {
            throw new System.NotImplementedException();
        }

        public override void ExecuteMove(Board board, Coordinate destination) {
            throw new System.NotImplementedException();
        }

        public override object Clone() {
            return new CheckersKing(CurrentCoordinate, Player);
        }

    }
}