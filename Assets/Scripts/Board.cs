using System;
using System.Collections.Generic;
using Checkers;
using Chess;
using JetBrains.Annotations;

public struct Board : ICloneable {

    public int Row;
    public int Column;
    [ItemCanBeNull] public Piece[,] Matrix;
    
    public Board(int row, int column) {
        Row = row;
        Column = column;
        Matrix = new Piece[Row, Column];
    }

    public Piece GetPiece(Coordinate coordinate) {
        return Matrix[coordinate.Row, coordinate.Column];
    }
    
    public IEnumerable<Piece> AvailablePieces(PlayerColor playerColor) {
        foreach (Piece piece in Matrix) {
            if (piece == null) continue;
            if (piece.Player == playerColor) yield return piece;
        }
    }
    
    public bool OccupiedCoordinate(Coordinate coordinate, PlayerColor? playerColor = null) {
        if (playerColor == null) return Matrix[coordinate.Row, coordinate.Column] != null;
        return Matrix[coordinate.Row, coordinate.Column]?.Player == playerColor;
    }
    
    public bool ValidCoordinate(Coordinate coordinate) {
        return coordinate.Row >= 0 && coordinate.Row < Matrix.GetLength(0) && 
               coordinate.Column >= 0 && coordinate.Column < Matrix.GetLength(1);
    }

    public int Evaluate(PlayerColor playerColor) {
        int value = 0;
        foreach (Piece piece in Matrix) {
            if (piece == null) continue;
            value += piece.Value * (playerColor == piece.Player ? 1 : -1);
        }
        return value;
    }

    public void ConvertHandyMatrix(Pieces[,] handyMatrix) {
        Matrix = new Piece[handyMatrix.GetLength(0), handyMatrix.GetLength(1)];
        for (int i = 0; i < handyMatrix.GetLength(0); i++) {
            for (int j = 0; j < handyMatrix.GetLength(1); j++) {
                switch (handyMatrix[j, i]) {
                    case Pieces.None:
                        break;
                    case Pieces.WhiteChessPawn:
                        Matrix[i, j] = new ChessPawn(new Coordinate(i, j), PlayerColor.White);
                        break;
                    case Pieces.BlackChessPawn:
                        Matrix[i, j] = new ChessPawn(new Coordinate(i, j), PlayerColor.Black);
                        break;
                    case Pieces.WhiteChessRook:
                        Matrix[i, j] = new ChessRook(new Coordinate(i, j), PlayerColor.White);
                        break;
                    case Pieces.BlackChessRook:
                        Matrix[i, j] = new ChessRook(new Coordinate(i, j), PlayerColor.Black);
                        break;
                    case Pieces.WhiteChessKnight:
                        Matrix[i, j] = new ChessKnight(new Coordinate(i, j), PlayerColor.White);
                        break;
                    case Pieces.BlackChessKnight:
                        Matrix[i, j] = new ChessKnight(new Coordinate(i, j), PlayerColor.Black);
                        break;
                    case Pieces.WhiteChessBishop:
                        Matrix[i, j] = new ChessBishop(new Coordinate(i, j), PlayerColor.White);
                        break;
                    case Pieces.BlackChessBishop:
                        Matrix[i, j] = new ChessBishop(new Coordinate(i, j), PlayerColor.Black);
                        break;
                    case Pieces.WhiteChessQueen:
                        Matrix[i, j] = new ChessQueen(new Coordinate(i, j), PlayerColor.White);
                        break;
                    case Pieces.BlackChessQueen:
                        Matrix[i, j] = new ChessQueen(new Coordinate(i, j), PlayerColor.Black);
                        break;
                    case Pieces.WhiteChessKing:
                        Matrix[i, j] = new ChessKing(new Coordinate(i, j), PlayerColor.White);
                        break;
                    case Pieces.BlackChessKing:
                        Matrix[i, j] = new ChessKing(new Coordinate(i, j), PlayerColor.Black);
                        break;
                    case Pieces.WhiteCheckersMen:
                        Matrix[i, j] = new CheckersMen(new Coordinate(i, j), PlayerColor.White);
                        break;
                    case Pieces.BlackCheckersMen:
                        Matrix[i, j] = new CheckersMen(new Coordinate(i, j), PlayerColor.Black);
                        break;
                    case Pieces.WhiteCheckersKing:
                        Matrix[i, j] = new CheckersKing(new Coordinate(i, j), PlayerColor.White);
                        break;
                    case Pieces.BlackCheckersKing:
                        Matrix[i, j] = new CheckersKing(new Coordinate(i, j), PlayerColor.Black);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
    
    public object Clone() {
        Board board = new Board(Row, Column);
        for (int i = 0; i < Matrix.GetLength(0); i++) {
            for (int j = 0; j < Matrix.GetLength(1); j++) {
                board.Matrix[i, j] = (Piece) Matrix[i, j]?.Clone();
            }
        }
        return board;
    }

}