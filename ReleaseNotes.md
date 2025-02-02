# 1.3.0-a prerelease
- Update all nuget package references
- Exposes a ProcessDto that is used for processing work on a table like a queue. 
- Use with WorkProcessService (no protection), LockedWorkProcessService (semaphore) and SingleWorkProcessService (single server)
