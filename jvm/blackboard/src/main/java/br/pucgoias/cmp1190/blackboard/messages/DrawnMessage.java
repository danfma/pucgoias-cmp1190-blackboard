package br.pucgoias.cmp1190.blackboard.messages;

import br.pucgoias.cmp1190.blackboard.shapes.Shape;

/**
 * Created by danfma on 02/12/15.
 */
public class DrawnMessage implements Message {
    private Shape shape;
    private int order;

    public DrawnMessage(Shape shape, int order) {
        this.shape = shape;
        this.order = order;
    }

    public Shape getShape() {
        return shape;
    }

    public int getOrder() {
        return order;
    }
}
