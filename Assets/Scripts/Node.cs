using System;
using System.Collections.Generic;
using System.Linq;

public class Node {

    public Board Board;
    public PlayerColor PlayerEval;
    public PlayerColor PlayerTurn;
    public Coordinate MoveOrigin;
    public Coordinate MoveDestination;
    public int HeuristicValue;
        
    public PlayerColor OtherPlayerTurn => PlayerTurn == PlayerColor.White ? PlayerColor.Black : PlayerColor.White;

    public IEnumerable<Node> Children {
        get {
            foreach (Piece availablePiece in Board.AvailablePieces(OtherPlayerTurn)) {
                foreach (Coordinate availableMove in availablePiece.AvailableMoves(Board)) {
                    yield return new Node(Board, PlayerEval, OtherPlayerTurn, availablePiece.CurrentCoordinate, availableMove);
                }
            }
        }
    }

    public bool IsTerminal {
        get { return !Children.Any(); }
    }

    public Node(Board board, PlayerColor playerEval, PlayerColor playerTurn, Coordinate moveOrigin, Coordinate moveDestination) {
        Board = (Board) board.Clone();
        PlayerEval = playerEval;
        PlayerTurn = playerTurn;
        MoveOrigin = moveOrigin;
        MoveDestination = moveDestination;
        Piece piece = Board.GetPiece(MoveOrigin);
        if (piece == null) throw new Exception("Cannot get piece on origin : " + moveOrigin.Row + " " + moveOrigin.Column);
        Board.GetPiece(MoveOrigin).ExecuteMove(Board, MoveDestination);
        HeuristicValue = Board.Evaluate(PlayerEval);
    }
        
}