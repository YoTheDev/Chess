using System.Collections.Generic;

namespace Chess {
    public class ChessQueen : Piece {
        
        public ChessQueen(Coordinate currentCoordinate, PlayerColor player) : base(currentCoordinate, player) { }
        
        public override int Value => 10;

        public override List<Coordinate> AvailableMoves(Board board) {
            List<Coordinate> availableMoves = new List<Coordinate>();
            // Moves to the right
            for (Coordinate coordinate = CurrentCoordinate.ToRight; board.ValidCoordinate(coordinate); coordinate += Coordinate.Right) {
                if (board.OccupiedCoordinate(coordinate, Player)) break;
                availableMoves.Add(coordinate);
                if (board.OccupiedCoordinate(coordinate)) break;
            }
            // Moves to the left
            for (Coordinate coordinate = CurrentCoordinate.ToLeft; board.ValidCoordinate(coordinate); coordinate += Coordinate.Right) {
                if (board.OccupiedCoordinate(coordinate, Player)) break;
                availableMoves.Add(coordinate);
                if (board.OccupiedCoordinate(coordinate)) break;
            }
            // Moves to the top
            for (Coordinate coordinate = CurrentCoordinate.ToTop; board.ValidCoordinate(coordinate); coordinate += Coordinate.Top) {
                if (board.OccupiedCoordinate(coordinate, Player)) break;
                availableMoves.Add(coordinate);
                if (board.OccupiedCoordinate(coordinate)) break;
            }
            // Moves to the bottom
            for (Coordinate coordinate = CurrentCoordinate.ToBottom; board.ValidCoordinate(coordinate); coordinate += Coordinate.Bottom) {
                if (board.OccupiedCoordinate(coordinate, Player)) break;
                availableMoves.Add(coordinate);
                if (board.OccupiedCoordinate(coordinate)) break;
            }
            // Moves to the topRight
            for (Coordinate coordinate = CurrentCoordinate.ToTopRight; board.ValidCoordinate(coordinate); coordinate += Coordinate.TopRight) {
                if (board.OccupiedCoordinate(coordinate, Player)) break;
                availableMoves.Add(coordinate);
                if (board.OccupiedCoordinate(coordinate)) break;
            }
            // Moves to the bottomRight
            for (Coordinate coordinate = CurrentCoordinate.ToBottomRight; board.ValidCoordinate(coordinate); coordinate += Coordinate.BottomRight) {
                if (board.OccupiedCoordinate(coordinate, Player)) break;
                availableMoves.Add(coordinate);
                if (board.OccupiedCoordinate(coordinate)) break;
            }
            // Moves to the bottomLeft
            for (Coordinate coordinate = CurrentCoordinate.ToBottomLeft; board.ValidCoordinate(coordinate); coordinate += Coordinate.BottomLeft) {
                if (board.OccupiedCoordinate(coordinate, Player)) break;
                availableMoves.Add(coordinate);
                if (board.OccupiedCoordinate(coordinate)) break;
            }
            // Moves to the topLeft
            for (Coordinate coordinate = CurrentCoordinate.ToTopLeft; board.ValidCoordinate(coordinate); coordinate += Coordinate.TopLeft) {
                if (board.OccupiedCoordinate(coordinate, Player)) break;
                availableMoves.Add(coordinate);
                if (board.OccupiedCoordinate(coordinate)) break;
            }
            return availableMoves;
        }

        public override void ExecuteMove(Board board, Coordinate destination) {
            // Move to position
            board.Matrix[destination.Row, destination.Column] = board.Matrix[CurrentCoordinate.Row, CurrentCoordinate.Column];
            board.Matrix[CurrentCoordinate.Row, CurrentCoordinate.Column] = null;
            CurrentCoordinate = destination;
        }

        public override object Clone() {
            return new ChessQueen(CurrentCoordinate, Player);
        }


    }
}