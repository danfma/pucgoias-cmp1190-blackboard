package br.pucgoias.cmp1190.blackboard.messages;

/**
 * Created by danfma on 02/12/15.
 */
public class ListOfBoardsMessage implements Message {
    private String[] boardsUrl;

    public ListOfBoardsMessage(String[] boardsUrl) {
        this.boardsUrl = boardsUrl;
    }

    public String[] getBoardsUrl() {
        return boardsUrl;
    }
}
