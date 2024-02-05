using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Collections.Generic;
using System.Numerics;

namespace Infrastructure.Services
{
    public class DataReviewService
    {
        private readonly DataReviewRepo _reviewRepository;
        private readonly DataCustomerService _customerService;
        private readonly DataProductService _productService;

        public DataReviewService(DataReviewRepo reviewRepository, DataCustomerService customerService, DataProductService productService)
        {
            _reviewRepository = reviewRepository;
            _customerService = customerService;
            _productService = productService;
        }

        // Create
        public Review CreateReview(string firstName, string lastName, string email, string phone, string productName, string description, string manufacturerName, string categoryName, int rating, string comments)
        {
            var customerEntity = _customerService.CreateCustomer(firstName, lastName, email, phone);
            var productEntity = _productService.CreateProduct(productName, description, manufacturerName, categoryName);

            var reviewEntity = new Review
            {
                Rating = rating,
                Comments = comments,
                CustomerId = customerEntity?.CustomerId,
                ProductId = productEntity?.ProductId
            };

            reviewEntity = _reviewRepository.Create(reviewEntity);

            return reviewEntity;
        }

        // Read
        public Review GetReviewById(int id)
        {
            var reviewEntity = _reviewRepository.Get(x => x.ReviewId == id);
            return reviewEntity;
        }

        public IEnumerable<Review> GetReviews()
        {
            var reviews = _reviewRepository.GetAll();
            return reviews;
        }

        // Update
        public Review UpdateReview(Review reviewEntity)
        {
            var updatedReviewEntity = _reviewRepository.Update(x => x.ReviewId == reviewEntity.ReviewId, reviewEntity);
            return updatedReviewEntity;
        }

        // Delete
        public void DeleteReview(int id)
        {
            _reviewRepository.Delete(x => x.ReviewId == id);
        }
    }
}