# File Search App

This project is a file search application that uses Elasticsearch, ASP.NET Core, and Angular. It allows users to search for files based on their names and contents.

## Prerequisites

- Docker and Docker Compose
- Node.js
- .NET SDK

## Setup

1. Clone the repository:
```bash
   git clone https://github.com/yourusername/file-search-app.git
   cd file-search-app
```

2. Build and run the Docker containers:
```bash
    docker-compose up --build
```

3. Access the application:
- Elasticsearch: http://localhost:9200
- Backend API: http://localhost:5000
- Frontend: http://localhost:4200

## Project Structure
- `FileSearchAPI/`: The ASP.NET Core backend API.
- `file-search-app/`: The Angular frontend application.
- `docker-compose.yml`: Docker Compose file to manage the services.
- `Dockerfile.elasticsearch`: Dockerfile for Elasticsearch with the ingest-attachment plugin.

## Contributing
Contributions are welcome! Please open an issue or submit a pull request.

## License
This project is licensed under the MIT License.
