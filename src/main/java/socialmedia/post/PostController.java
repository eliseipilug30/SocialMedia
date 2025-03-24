package socialmedia.post;

import socialmedia.post.Status;
import socialmedia.user.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/posts")
public class PostController {

    @Autowired
    private PostService postService;


    @PostMapping
    public Post createPost(@RequestBody Post post) {
        if (post.getStatus() == null) {
            post.setStatus(Status.PENDING);
        }
        return postService.createPost(post);
    }


    @GetMapping
    public List<Post> getAllPosts() {
        return postService.getAllPosts();
    }


    @GetMapping("/{id}")
    public Post getPostById(@PathVariable Integer id) {
        return postService.getPostById(id);
    }


    @PutMapping("/{id}")
    public Post updatePost(@PathVariable Integer id, @RequestBody Post updatedPost) {
        return postService.updatePost(id, updatedPost);
    }


    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deletePost(@PathVariable Integer id) {
        postService.deletePost(id);
        return ResponseEntity.noContent().build();
    }


    @GetMapping("/search")
    public List<Post> getPostsByKeyword(@RequestParam String keyword) {
        return postService.searchPostsByKeyword(keyword);
    }
}
