package br.pucgoias.cmp1190.blackboard.messages;

import br.pucgoias.cmp1190.blackboard.shapes.Shape;

/**
 * Created by danfma on 02/12/15.
 */
public class DrawMessage implements Message {
    private Shape shape;

    public DrawMessage(Shape shape) {
        this.shape = shape;
    }

    public Shape getShape() {
        return shape;
    }
}
