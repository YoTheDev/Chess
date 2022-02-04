using System;
using System.Collections.Generic;

public abstract class Piece : ICloneable {

    public Coordinate CurrentCoordinate;
    public PlayerColor Player;
    
    public PlayerColor OtherPlayer => Player == PlayerColor.Black ? PlayerColor.White : PlayerColor.Black;
    
    public abstract int Value { get; }
    
    protected Piece(Coordinate currentCoordinate, PlayerColor player) {
        CurrentCoordinate = currentCoordinate;
        Player = player;
    }
    
    public abstract List<Coordinate> AvailableMoves(Board board);
    public abstract void ExecuteMove(Board board, Coordinate destination);
    public abstract object Clone();
        
}