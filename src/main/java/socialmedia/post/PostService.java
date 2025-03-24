package socialmedia.post;

import socialmedia.user.UserRepository;
import socialmedia.user.User;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class PostService {

    @Autowired
    private PostRepository postRepository;

    @Autowired
    private UserRepository userRepository;


    public Post createPost(Post post) {
        if (post.getUser() != null) {
            Integer userId = post.getUser().getId();
            User user = userRepository.findById(userId)
                    .orElseThrow(() -> new RuntimeException("User not found"));
            post.setUser(user);
        }
        return postRepository.save(post);
    }


    public List<Post> getAllPosts() {
        return postRepository.findAll();
    }


    public Post getPostById(Integer id) {
        return postRepository.findById(id)
                .orElseThrow(() -> new RuntimeException("Post not found"));
    }


    public Post updatePost(Integer id, Post updatedPost) {
        Post existingPost = postRepository.findById(id)
                .orElseThrow(() -> new RuntimeException("Post not found"));


        existingPost.setTitle(updatedPost.getTitle());
        existingPost.setContent(updatedPost.getContent());
        existingPost.setStatus(updatedPost.getStatus());

        if (updatedPost.getUser() != null) {
            Integer userId = updatedPost.getUser().getId();
            User user = userRepository.findById(userId)
                    .orElseThrow(() -> new RuntimeException("User not found"));
            existingPost.setUser(user);
        }

        return postRepository.save(existingPost);
    }


    public void deletePost(Integer id) {
        if (!postRepository.existsById(id)) {
            throw new RuntimeException("Post not found");
        }
        postRepository.deleteById(id);
    }


    public List<Post> searchPostsByKeyword(String keyword) {
        return postRepository.searchPostsByKeyword(keyword);
    }
}
