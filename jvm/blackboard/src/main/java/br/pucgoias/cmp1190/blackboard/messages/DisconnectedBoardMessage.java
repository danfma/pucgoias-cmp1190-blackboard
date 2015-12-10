package br.pucgoias.cmp1190.blackboard.messages;

/**
 * Created by danfma on 02/12/15.
 */
public class DisconnectedBoardMessage {
    private String boardUrl;

    public DisconnectedBoardMessage(String boardUrl) {
        this.boardUrl = boardUrl;
    }

    public String getBoardUrl() {
        return boardUrl;
    }
}
