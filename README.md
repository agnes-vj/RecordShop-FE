
# **🎶 Melody Record Shop Frontend 🎶**

Welcome to the **Melody Record Shop Frontend** project! This is a Blazor Web app used to display and interact with a catalog of albums in the Melody Record Shop. The frontend fetches and displays a list of albums, allowing users to view, add, delete, and search for records.



### **Features**
- **Album Listing**: View a paginated list of albums with details.
- **Album Management**: Add, edit, and delete albums.
- **Virtualized Display**: Efficiently load and render large album lists.
- **Search**: Search albums based on artist name or title.


---


### **Navigating the Application**

- **Home Page**: The home page displays a Featured Album.
- **Albums**: List of albums using a **virtualized** list, which only renders albums visible in the viewport to improve performance. You can scroll to load more albums as you go.
- **Album Details**: Each album is clickable, and you can view more details (like the album name, artist, etc.).
- **Update/Delete Albums**: You can update album information or delete an album using buttons in Album Details. Deleting albums updates the list dynamically.
- **Add Albums**: New Albums can be added using this link.
- **Search**: Search Albums with it's Id/Name/ArtistName

### **Interaction with the API**
This frontend interacts with an API backend (not included in this repository). The API is responsible for providing album data. The frontend fetches album data and renders it dynamically.

---

## **Technologies Used**

- **Blazor Web App**: For building interactive web applications.
- **C#**: Main programming language for both frontend and logic handling.
- **.NET 8**: The framework used for building the app.
- **Bootstrap 5**: For responsive layout and design.
- **Virtualize Component**: For efficient rendering of large lists (like albums).

---
