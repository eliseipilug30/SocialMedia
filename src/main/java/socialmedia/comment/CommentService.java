package socialmedia.comment;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class CommentService {

    @Autowired
    private CommentRepository commentRepository;


    public Comment createComment(Comment comment) {
        return commentRepository.save(comment);
    }


    public List<Comment> getAllComments() {
        return commentRepository.findAll();
    }


    public Comment getCommentById(Integer id) {
        return commentRepository.findById(id)
                .orElseThrow(() -> new RuntimeException("Comment not found"));
    }


    public Comment updateComment(Integer id, Comment updatedComment) {
        Comment existingComment = getCommentById(id);
        existingComment.setContent(updatedComment.getContent());
        return commentRepository.save(existingComment);
    }


    public void deleteComment(Integer id) {
        if (!commentRepository.existsById(id)) {
            throw new RuntimeException("Comment not found");
        }
        commentRepository.deleteById(id);
    }


    public List<Comment> getAllCommentsForPost(Integer postId) {
        return commentRepository.findAllCommentsByPostId(postId);
    }


    public List<Comment> searchCommentsByKeyword(String keyword) {
        return commentRepository.searchCommentsByKeyword(keyword);
    }
}
