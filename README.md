![ServiceBricks Logo](https://raw.githubusercontent.com/holomodular/ServiceBricks/main/Logo.png)  

[![NuGet version](https://badge.fury.io/nu/ServiceBricks.Work.Microservice.svg)](https://badge.fury.io/nu/ServiceBricks.Work.Microservice)
[![License: MIT](https://img.shields.io/badge/License-MIT-389DA0.svg)](https://opensource.org/licenses/MIT)

# ServiceBricks Work Microservice

## Overview

This repository contains the work microservice built using the ServiceBricks foundation.
The work microservice exposes a ProcessDto object used to store a ProcessQueue, ProcessType and ProcessData properties that are used to process work from a table like a queue using the WorkService class.
It exposes an abstract class WorkProcessService that encapsulates the functionality for you.

## Data Transfer Objects

### ProcessDto - Admin Policy
Used to process a table like a queue.

```csharp

public partial class ProcessDto : DataTransferObject, IDpWorkProcess
{
    /// <summary>
    /// This is the create date.
    /// </summary>
    public DateTimeOffset CreateDate { get; set; }

    /// <summary>
    /// This is the update date.
    /// </summary>
    public DateTimeOffset UpdateDate { get; set; }

    /// <summary>
    /// The queue name.
    /// </summary>
    public string ProcessQueue { get; set; }

    /// <summary>
    /// The work type.
    /// </summary>
    public string ProcessType { get; set; }

    /// <summary>
    /// The work details.
    /// </summary>
    public string ProcessData { get; set; }

    /// <summary>
    /// Determine if completed processing.
    /// </summary>
    public bool IsComplete { get; set; }

    /// <summary>
    /// Determine if an error occured.
    /// </summary>
    public bool IsError { get; set; }

    /// <summary>
    /// Determine if currently processing.
    /// </summary>
    public bool IsProcessing { get; set; }

    /// <summary>
    /// The retry count.
    /// </summary>
    public int RetryCount { get; set; }

    /// <summary>
    /// The processing date.
    /// </summary>
    public DateTimeOffset ProcessDate { get; set; }

    /// <summary>
    /// The future processing date.
    /// </summary>
    public DateTimeOffset FutureProcessDate { get; set; }

    /// <summary>
    /// The process response.
    /// </summary>
    public string ProcessResponse { get; set; }
}

```

## Background Tasks and Timers

None

## Events
None

## Processes
None

## Service Bus
None

## Additional

### WorkProcessService class
This abstract class provides the functionality to process the ProcessDto table like a queue. Each derived class should set the ProcessQueue name, so the table can be used with multiple-queues.
It relies on the ServiceBricks Cache Microservice to provide a distributed semaphore, to provide a gate with multiple servers running.

## Application Settings
None

# About ServiceBricks

ServiceBricks is the cornerstone for building a microservices foundation.
Visit https://ServiceBricks.com to learn more.

