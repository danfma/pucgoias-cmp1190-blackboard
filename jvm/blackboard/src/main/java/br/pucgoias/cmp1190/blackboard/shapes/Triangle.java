package br.pucgoias.cmp1190.blackboard.shapes;

/**
 * Created by danfma on 02/12/15.
 */
public class Triangle extends Shape {
    private final Position center;
    private final int width;
    private final int height;

    public Triangle(Position center, int width, int height, String borderColor, String backgroundColor) {
        super(ShapeType.Triangle, borderColor, backgroundColor);
        this.center = center;
        this.width = width;
        this.height = height;
    }

    public Position getCenter() {
        return center;
    }

    public int getWidth() {
        return width;
    }

    public int getHeight() {
        return height;
    }
}
