public struct Coordinate {

    public int Row;
    public int Column;

    public static Coordinate Zero => new Coordinate(0, 0);
    public static Coordinate Top => new Coordinate(1, 0);
    public static Coordinate TopRight => new Coordinate(1, 1);
    public static Coordinate Right => new Coordinate(0, 1);
    public static Coordinate BottomRight => new Coordinate(-1, 1);
    public static Coordinate Bottom => new Coordinate(-1, 0);
    public static Coordinate BottomLeft => new Coordinate(-1, -1);
    public static Coordinate Left => new Coordinate(0, -1);
    public static Coordinate TopLeft => new Coordinate(1, -1);

    public Coordinate ToTop => this + Top;
    public Coordinate ToTopRight => this + TopRight;
    public Coordinate ToRight => this + Right;
    public Coordinate ToBottomRight => this + BottomRight;
    public Coordinate ToBottom => this + Bottom;
    public Coordinate ToBottomLeft => this + BottomLeft;
    public Coordinate ToLeft => this + Left;
    public Coordinate ToTopLeft => this + TopLeft;

    public Coordinate ToTopJump => this + Top * 2;
    public Coordinate ToTopRightJump => this + TopRight * 2;
    public Coordinate ToRightJump => this + Right * 2;
    public Coordinate ToBottomRightJump => this + BottomRight * 2;
    public Coordinate ToBottomJump => this + Bottom * 2;
    public Coordinate ToBottomLeftJump => this + BottomLeft * 2;
    public Coordinate ToLeftJump => this + Left * 2;
    public Coordinate ToTopLeftJump => this + TopLeft * 2;

    public Coordinate(int row, int column) {
        Row = row;
        Column = column;
    }

    public static Coordinate operator +(Coordinate a) => a;
    
    public static Coordinate operator -(Coordinate a) => new Coordinate(-a.Row, -a.Column);

    public static Coordinate operator +(Coordinate a, Coordinate b) => new Coordinate(a.Row + b.Row, a.Column + b.Column);

    public static Coordinate operator -(Coordinate a, Coordinate b) => new Coordinate(a.Row - b.Row, a.Column - b.Column);

    public static Coordinate operator *(Coordinate a, int b) => new Coordinate(a.Row * b, a.Column * b);
    
    public static Coordinate operator *(Coordinate a, Coordinate b) => new Coordinate(a.Row * b.Row, a.Column * b.Column);

    public static Coordinate operator /(Coordinate a, Coordinate b) => new Coordinate(a.Row / b.Row, a.Column / b.Column);
    
    public override string ToString() {
        return "Coordinate : " + Row + " " + Column;
    }
        
}