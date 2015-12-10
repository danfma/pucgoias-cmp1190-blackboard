package br.pucgoias.cmp1190.blackboard.messages;

/**
 * Created by danfma on 02/12/15.
 */
public class ConnectedBoardMessage implements Message {
    private final String boardUrl;

    public ConnectedBoardMessage(String boardUrl) {
        this.boardUrl = boardUrl;
    }

    public String getBoardUrl() {
        return boardUrl;
    }
}
