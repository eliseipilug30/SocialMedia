package socialmedia.post;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.util.List;

public interface PostRepository extends JpaRepository<Post, Integer> {


    @Query("SELECT p FROM Post p WHERE p.status = 'PUBLISHED' AND p.user.id = :userId")
    List<Post> findAllPublishedPostsByUserId(@Param("userId") Integer userId);


    @Query("SELECT p FROM Post p WHERE LOWER(p.title) LIKE LOWER(CONCAT('%', :keyword, '%')) OR LOWER(p.content) LIKE LOWER(CONCAT('%', :keyword, '%'))")
    List<Post> searchPostsByKeyword(@Param("keyword") String keyword);
}
