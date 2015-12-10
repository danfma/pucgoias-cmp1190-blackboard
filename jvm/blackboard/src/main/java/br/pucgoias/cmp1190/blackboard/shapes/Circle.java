package br.pucgoias.cmp1190.blackboard.shapes;

/**
 * Created by danfma on 02/12/15.
 */
public class Circle extends Shape {
    private final Position center;
    private final int radius;

    public Circle(Position center, int radius, String borderColor, String backgroundColor) {
        super(ShapeType.Circle, borderColor, backgroundColor);
        this.center = center;
        this.radius = radius;
    }

    public Position getCenter() {
        return center;
    }

    public int getRadius() {
        return radius;
    }
}
