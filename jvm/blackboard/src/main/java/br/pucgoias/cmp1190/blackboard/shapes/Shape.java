package br.pucgoias.cmp1190.blackboard.shapes;

import java.io.Serializable;

/**
 * Created by danfma on 02/12/15.
 */
public abstract class Shape implements Serializable {
    private final ShapeType type;
    private final String borderColor;
    private final String backgroundColor;

    protected Shape(ShapeType type, String borderColor, String backgroundColor) {

        this.type = type;
        this.borderColor = borderColor;
        this.backgroundColor = backgroundColor;
    }

    public ShapeType getType() {
        return type;
    }

    public String getBorderColor() {
        return borderColor;
    }

    public String getBackgroundColor() {
        return backgroundColor;
    }
}
