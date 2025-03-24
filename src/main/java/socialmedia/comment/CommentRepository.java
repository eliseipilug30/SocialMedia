package socialmedia.comment;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.util.List;

public interface CommentRepository extends JpaRepository<Comment, Integer> {


    @Query("SELECT c FROM Comment c WHERE c.post.id = :postId")
    List<Comment> findAllCommentsByPostId(@Param("postId") Integer postId);


    @Query("SELECT c FROM Comment c WHERE LOWER(c.content) LIKE LOWER(CONCAT('%', :keyword, '%'))")
    List<Comment> searchCommentsByKeyword(@Param("keyword") String keyword);
}
