package br.pucgoias.cmp1190.blackboard.shapes;

/**
 * Created by danfma on 02/12/15.
 */
public class Box extends Shape {
    private final Position center;
    private final int width;
    private final int height;

    public Box(Position center, int width, int height, String borderColor, String backgroundColor) {
        super(ShapeType.Box, borderColor, backgroundColor);
        this.center = center;
        this.width = width;
        this.height = height;
    }

    public int getHeight() {
        return height;
    }

    public Position getCenter() {
        return center;
    }

    public int getWidth() {
        return width;
    }
}
