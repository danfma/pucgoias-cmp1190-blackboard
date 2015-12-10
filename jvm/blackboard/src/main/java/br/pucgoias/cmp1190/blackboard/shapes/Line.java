package br.pucgoias.cmp1190.blackboard.shapes;

/**
 * Created by danfma on 02/12/15.
 */
public class Line extends Shape {

    private final Position start;
    private final Position end;

    public Line(Position start, Position end, String borderColor, String backgroundColor) {
        super(ShapeType.Line, borderColor, backgroundColor);
        this.start = start;
        this.end = end;
    }


    public Position getStart() {
        return start;
    }

    public Position getEnd() {
        return end;
    }
}
