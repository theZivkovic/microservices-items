### Microservices/Items service

A .NET 9 web API that acts as a microservice in the cluster: https://github.com/theZivkovic/microservices

### Features

- Clean Architecture design
- CI pipeline using Github actions (builds and caches Docker images via Docker Hub)
- Create/Read/Delete (CRD) of _Items_ entities
- Audit log of CRD actions via http calls to audit-logs microservice (https://github.com/theZivkovic/microservices-audit-logs)
- Pagination middleware
- Serilog logging
- Request retry logic with Polly
